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
        public string Service_Name { get; set; }
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public InventoryType Inventory_Type { get; set; }
    }
}
