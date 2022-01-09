using System;
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
        public int EmployeeID { get; set; }
        [Required]
        public virtual Provider Provider { get; set; }
        public int ProviderID { get; set; }
        [Required]
        public virtual PurchaseRequisition PurchaseRequisition { get; set; }
        public int PurchaseRequisitionID { get; set; }
        [Required]
        public DateTime DeliveryContractDate { get; set; }

        public DeliveryContract()
        {

        }
        public DeliveryContract(int EmployeeID, int ProviderID, int PurchaseRequisitionID, DateTime DeliveryContractDate)
        {
            this.EmployeeID = EmployeeID;
            this.ProviderID = ProviderID;
            this.PurchaseRequisitionID = PurchaseRequisitionID;
            this.DeliveryContractDate = DeliveryContractDate;
        }
    }
}
