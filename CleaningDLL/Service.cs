using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Service //Услуга
    {
        public int ID { get; set; }
        [Required]
        public string Service_Number { get; set; }
        [Required]
        public string Service_Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ReferenceUnitsOfMeasurement Unit { get; set; }
        [Required]
        public decimal Price { get; set; }
        public Inventory_Type Inventory_Type { get; set; }
        public Provided_Service Provided_Service { get; set; }
        public Consumption_Rate Consumption_Rate { get; set; }
    }
}
