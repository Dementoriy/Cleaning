using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Delivery //Поставка
    {
        public int ID { get; set; }
        [Required]
        public virtual Provider Provider { get; set; }
        public int ProviderID { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public decimal DeliveryCost { get; set; }
        [Required]
        public virtual DeliveryContent DeliveryContent { get; set; }
        public int DeliveryContentID { get; set; }

        public Delivery()
        {

        }
        public Delivery(int ProviderID, DateTime DeliveryDate, decimal DeliveryCost, int DeliveryContentID)
        {
            this.ProviderID = ProviderID;
            this.DeliveryDate = DeliveryDate;
            this.DeliveryCost = DeliveryCost;
            this.DeliveryContentID = DeliveryContentID;
        }
    }
}
