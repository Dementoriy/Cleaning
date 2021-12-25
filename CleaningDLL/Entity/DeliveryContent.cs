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
        [Required]
        public int Delivery_Content_Amount { get; set; }
}
}
