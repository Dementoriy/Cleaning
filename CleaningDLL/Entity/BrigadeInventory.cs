using System.ComponentModel.DataAnnotations;

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
        public BrigadeInventory(Brigade Brigade, Inventory Inventory)
        {
            this.Brigade = Brigade;
            this.Inventory = Inventory;
        }
    }
}
