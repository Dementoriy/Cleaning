﻿using System.ComponentModel.DataAnnotations;

namespace CleaningDLL.Entity
{
    public class DeliveryContent //Содержимое поставки
    {
        public int ID { get; set; }
        [Required]
        public virtual Consumable Consumable { get; set; }
        [Required]
        public int DeliveryContentAmount { get; set; }

        public DeliveryContent()
        {

        }
        public DeliveryContent(Consumable Consumable, int DeliveryContentAmount)
        {
            this.Consumable = Consumable;
            this.DeliveryContentAmount = DeliveryContentAmount;
        }
    }
}
