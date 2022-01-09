using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public RequisitionContent(int ConsumableID, int Amount)
        {
            this.ConsumableID = ConsumableID;
            this.Amount = Amount;
        }
    }
}
