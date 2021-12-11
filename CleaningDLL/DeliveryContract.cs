using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class DeliveryContract //Договор на поставку
    {
        public int ID { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Provider Provider { get; set; }
        [Required]
        public PurchaseRequisition Purchase_Requisition { get; set; }
        [Required]
        public DateTime Delivery_Contract_Date { get; set; }
    }
}
