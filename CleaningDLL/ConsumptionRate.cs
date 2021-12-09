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
        public string Consumption { get; set; }
        public Consumable Consumable { get; set; }
        public ReferenceUnitsOfMeasurement Unit { get; set; }

    }
}
