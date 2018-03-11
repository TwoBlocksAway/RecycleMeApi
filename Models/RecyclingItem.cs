using RecycleMeAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleMeAPI.Models
{
    public class RecyclingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ContainerType ContainerType { get; set; }

        // Measurement unit: mL
        public double MaxSize { get; set; }

        // Currency is measure in cents
        [DataType(DataType.Currency)]
        public int RecyclingFee { get; set; }
        public string Instruction { get; set; }
        public bool Alcoholic { get; set; }
    }
}
