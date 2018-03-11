using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecycleMeAPI.Data;
using RecycleMeAPI.Models;

namespace RecycleMeAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/RecyclingItems")]
    public class RecyclingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecyclingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RecyclingItems
        [HttpGet]
        public IEnumerable<RecyclingItem> GetItems()
        {
            return _context.Items;
        }

        // GET: api/RecyclingItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecyclingItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recyclingItem = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);

            if (recyclingItem == null)
            {
                return NotFound();
            }

            return Ok(recyclingItem);
        }

        // PUT: api/RecyclingItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecyclingItem([FromRoute] int id, [FromBody] RecyclingItem recyclingItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recyclingItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(recyclingItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecyclingItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RecyclingItems
        [HttpPost]
        public async Task<IActionResult> PostRecyclingItem([FromBody] RecyclingItem recyclingItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Items.Add(recyclingItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecyclingItem", new { id = recyclingItem.Id }, recyclingItem);
        }

        // DELETE: api/RecyclingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecyclingItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var recyclingItem = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
            if (recyclingItem == null)
            {
                return NotFound();
            }

            _context.Items.Remove(recyclingItem);
            await _context.SaveChangesAsync();

            return Ok(recyclingItem);
        }

        private bool RecyclingItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}