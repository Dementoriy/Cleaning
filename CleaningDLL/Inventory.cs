using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Inventory //Инвентарь
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Inventory_Name { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }
        [Required]
        public virtual InventoryType Inventory_Type { get; set; }
        [Required]
        [MaxLength(50)] public string Use_Time { get; set; }
        [Required]
        [MaxLength(50)] public string Life_Time { get; set; }
        [Required]
        public DateTime Date_of_Receiving { get; set; }
    }
}
