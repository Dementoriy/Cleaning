using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class ConsumablesService //Расходники услуги
    {
        public int ID { get; set; }
        [Required]
        public virtual Service Service { get; set; }
        [Required]
        public virtual ConsumptionRate Consumption_Rate { get; set; }
    }
}
