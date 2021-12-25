using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Provider //Поставщик
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string CompanyName { get; set; }
        [Required]
        [MaxLength(12)] public string ProviderTelefonNumber { get; set; }
        [Required]
        public virtual Address ProviderAddress { get; set; }
    }
}
