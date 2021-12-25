using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class ProvidedService //Оказываемая услуга
    {
        public int ID { get; set; }
        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Service Service { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
