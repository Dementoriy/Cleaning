using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class RequisitionContent //Содержимое заявки на закупку
    {
        public int ID { get; set; }
        [Required]
        public virtual Consumable Consumable { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
