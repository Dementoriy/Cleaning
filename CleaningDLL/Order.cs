using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Order //Заявка
    {
        public int ID { get; set; }
        [Required]
        public string Status { get; set; }
        public Client Client{ get; set; }
        public Employee Employee { get; set; }
        public Address Address { get; set; }
        public Brigade Brigade { get; set; }

        public static List<Order> Get()
        {
            using (var db = new ApplicationContext())
            {
                return db.Order.ToList();
            }
        }
        public static List<OrderInfo> GetOrderInfo()
        {
            using (var db = new ApplicationContext())
            {
                return (from o in db.Order 
                        join ps in db.Provided_Service on o.ID equals ps.Order.ID
                        join s in db.Service on ps.Service.ID equals s.ID
                        select new OrderInfo()
                { 
                    Number = o.ID,
                    Brigade = o.Brigade.ID,
                    Status = o.Status,
                    Service = ps.Service.Service_Name
                }).ToList();
            }
        }
        public class OrderInfo
        {
            public int Number { get; set; }
            public string Status { get; set; }
            public int Brigade { get; set; }
            public string Service { get; set; }

        }
    }
    
}
