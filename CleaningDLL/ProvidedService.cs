using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class ProvidedService //Оказываемая услуга
    {
        public int ID { get; set; }
        public Order Order { get; set; }
        public Service Service { get; set; }
        [Required]
        public int Amount { get; set; }
        public ReferenceUnitsOfMeasurement ReferenceUnitsOfMeasurement { get; set; }
        public Inventory Inventory { get; set; }
    }
}
