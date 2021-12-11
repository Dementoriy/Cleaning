using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class ConsumptionRate //Норма расхода
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(150)] public string Consumption { get; set; }
        [Required]
        public Consumable Consumable { get; set; }
        [Required]
        public ReferenceUnitsOfMeasurement Unit { get; set; }

    }
}
