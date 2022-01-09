using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class BrigadeInventory //Инвентарь бригады
    {
        public int ID { get; set; }
        [Required]
        public virtual Brigade Brigade { get; set; }
        public int BrigadeID { get; set; }
        [Required]
        public virtual Inventory Inventory { get; set; }
        public int InventoryID { get; set; }

        public BrigadeInventory()
        {

        }
        public BrigadeInventory(int BrigadeID, int InventoryID)
        {
            this.BrigadeID = BrigadeID;
            this.InventoryID = InventoryID;
        }
    }
}
