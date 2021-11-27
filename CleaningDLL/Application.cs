using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Application //Заявка
    {
        public int ID { get; set; }
        [Required]
        public string Status { get; set; }
        public Client Client{ get; set; }
        public Employee Employee { get; set; }
        public Address Address { get; set; }
        public Brigade Brigade { get; set; }
    }
}
