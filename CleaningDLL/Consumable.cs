using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Consumable //Расходник
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Consumable_Name { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }
        [Required]
        public decimal Current_Price { get; set; }
        [Required]
        public ReferenceUnitsOfMeasurement Unit { get; set; }
        [Required]
        public int amount { get; set; }
    }
}
