using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecycleMeAPI.Data;
using RecycleMeAPI.Models;

namespace RecycleMeAPI.Controllers
{
    public class RecyclingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecyclingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecyclingItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: RecyclingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingItem = await _context.Items
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recyclingItem == null)
            {
                return NotFound();
            }

            return View(recyclingItem);
        }

        // GET: RecyclingItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecyclingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ContainerType,MaxSize,RecyclingFee,Instruction,Alcoholic")] RecyclingItem recyclingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recyclingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recyclingItem);
        }

        // GET: RecyclingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingItem = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
            if (recyclingItem == null)
            {
                return NotFound();
            }
            return View(recyclingItem);
        }

        // POST: RecyclingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ContainerType,MaxSize,RecyclingFee,Instruction,Alcoholic")] RecyclingItem recyclingItem)
        {
            if (id != recyclingItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recyclingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecyclingItemExists(recyclingItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recyclingItem);
        }

        // GET: RecyclingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recyclingItem = await _context.Items
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recyclingItem == null)
            {
                return NotFound();
            }

            return View(recyclingItem);
        }

        // POST: RecyclingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recyclingItem = await _context.Items.SingleOrDefaultAsync(m => m.Id == id);
            _context.Items.Remove(recyclingItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecyclingItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
