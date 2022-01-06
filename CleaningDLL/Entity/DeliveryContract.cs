﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class DeliveryContract //Договор на поставку
    {
        public int ID { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [Required]
        public virtual Provider Provider { get; set; }
        [Required]
        public virtual PurchaseRequisition Purchase_Requisition { get; set; }
        [Required]
        public DateTime Delivery_Contract_Date { get; set; }
    }
}