using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Contract //Договор с клиентом
    {
        public int ID { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        [Required]
        public DateTime Date_Of_Contract { get; set; }
    }
}
