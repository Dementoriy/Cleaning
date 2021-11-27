using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Inventory_Type //Тип инвентаря
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
