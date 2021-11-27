using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class PurchaseRequisition //Заявка на закупку
    {
        public int ID { get; set; }
        [Required]
        public string Status { get; set; }
        public Employee Employee { get; set; }
        public Provider Provider { get; set; }
        public RequisitionContent RequisitionContent { get; set; }
    }
}
