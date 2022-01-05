using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class ProvidedService //Оказываемая услуга
    {
        public int ID { get; set; }
        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public virtual Service Service { get; set; }
        public int ServiceID { get; set; }
        [Required]
        public int Amount { get; set; }


        private static ApplicationContext db = Context.Db;

        public static List<ProvidedService> GetPSByOrder(int id)
        {
            return (from ps in db.ProvidedService
                    where ps.Order.ID == id
                    select ps
                    ).ToList();
        }
    }
}
