using System.ComponentModel.DataAnnotations;

namespace CleaningDLL.Entity
{
    public class RequisitionContent //Содержимое заявки на закупку
    {
        public int ID { get; set; }
        [Required]
        public virtual Consumable Consumable { get; set; }
        public int ConsumableID { get; set; }
        [Required]
        public int Amount { get; set; }

        public RequisitionContent()
        {

        }
        public RequisitionContent(Consumable Consumable, int Amount)
        {
            this.Consumable = Consumable;
            this.Amount = Amount;
        }
    }
}
