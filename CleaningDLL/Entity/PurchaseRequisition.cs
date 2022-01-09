using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class PurchaseRequisition //Заявка на закупку
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Status { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public virtual Provider Provider { get; set; }
        public int ProviderID { get; set; }
        [Required]
        public virtual RequisitionContent RequisitionContent { get; set; }
        public int RequisitionContentID { get; set; }

        public PurchaseRequisition()
        {

        }
        public PurchaseRequisition(string Status, int EmployeeID, int ProviderID, int RequisitionContentID)
        {
            this.Status = Status;
            this.EmployeeID = EmployeeID;
            this.ProviderID = ProviderID;
            this.RequisitionContentID = RequisitionContentID;
        }
    }
}
