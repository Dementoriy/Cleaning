using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class DeliveryContent //Содержимое поставки
    {
        public int ID { get; set; }
        [Required]
        public virtual Consumable Consumable { get; set; }
        public int ConsumableID { get; set; }
        [Required]
        public int DeliveryContentAmount { get; set; }

        public DeliveryContent()
        {

        }
        public DeliveryContent(int ConsumableID, int DeliveryContentAmount)
        {
            this.ConsumableID = ConsumableID;
            this.DeliveryContentAmount = DeliveryContentAmount;
        }
    }
}
