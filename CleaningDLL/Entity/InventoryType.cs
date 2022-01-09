using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class InventoryType //Тип инвентаря
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(150)] public string Name { get; set; }

        public InventoryType()
        {

        }
        public InventoryType(string Name)
        {
            this.Name = Name;
        }
    }
}
