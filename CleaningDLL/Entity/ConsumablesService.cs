using System.ComponentModel.DataAnnotations;

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
        public ConsumablesService(Service Service, ConsumptionRate ConsumptionRate)
        {
            this.Service = Service;
            this.ConsumptionRate = ConsumptionRate;
        }
    }
}
