using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Provider //Поставщик
    {
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ProviderTelefonNumber { get; set; }
        public Address ProviderAddress { get; set; }
    }
}
