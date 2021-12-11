using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class ConsumablesService //Расходники услуги
    {
        public int ID { get; set; }
        [Required]
        public Service Service { get; set; }
        [Required]
        public ConsumptionRate Consumption_Rate { get; set; }
    }
}
