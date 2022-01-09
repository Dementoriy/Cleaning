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
        public int ServiceID { get; set; }
        [Required]
        public virtual ConsumptionRate ConsumptionRate { get; set; }
        public int ConsumptionRateID { get; set; }

        public ConsumablesService()
        {

        }
        public ConsumablesService(int ServiceID, int ConsumptionRateID)
        {
            this.ServiceID = ServiceID;
            this.ConsumptionRateID = ConsumptionRateID;
        }
    }
}
