using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Inventory //Инвентарь
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string InventoryName { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }
        [Required]
        public virtual InventoryType InventoryType { get; set; }
        public int InventoryTypeID { get; set; }
        [Required]
        [MaxLength(50)] public string UseTime { get; set; }
        [Required]
        [MaxLength(50)] public string LifeTime { get; set; }
        [Required]
        public DateTime DateOfReceiving { get; set; }

        public Inventory()
        {

        }
        public Inventory(string InventoryName, string Description, int InventoryTypeID, string UseTime, 
            string LifeTime, DateTime DateOfReceiving)
        {
            this.InventoryName = InventoryName;
            this.Description = Description;
            this.InventoryTypeID = InventoryTypeID;
            this.UseTime = UseTime;
            this.LifeTime = LifeTime;
            this.DateOfReceiving = DateOfReceiving;
        }
    }
}
