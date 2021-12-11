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
        [MaxLength(50)] public string CompanyName { get; set; }
        [Required]
        [MaxLength(11)] public string ProviderTelefonNumber { get; set; }
        [Required]
        public Address ProviderAddress { get; set; }
    }
}
