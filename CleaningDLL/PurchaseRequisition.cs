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
        [MaxLength(50)] public string Status { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Provider Provider { get; set; }
        [Required]
        public RequisitionContent RequisitionContent { get; set; }
    }
}
