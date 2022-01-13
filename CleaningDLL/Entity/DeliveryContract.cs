using System;
using System.ComponentModel.DataAnnotations;

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
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        [Required]
        public DateTime DeliveryContractDate { get; set; }

        public DeliveryContract()
        {

        }
        public DeliveryContract(Employee Employee, Provider Provider, PurchaseRequisition PurchaseRequisition, DateTime DeliveryContractDate)
        {
            this.Employee = Employee;
            this.Provider = Provider;
            this.PurchaseRequisition = PurchaseRequisition;
            this.DeliveryContractDate = DeliveryContractDate;
        }
    }
}
