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
        [MaxLength(50)] public string Status { get; set; }
        [Required]
        public Client Client{ get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
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
                        join a in db.Address on o.Address.ID equals a.ID
                        select new OrderInfo()

                { 
                    Brigade = o.Brigade.ID,
                    Status = o.Status,
                    Client = o.Client.AddFIO(),
                    Address = a.AddAddress(),
                    Telefone = o.Client.ClientTelefonNumber
                }).ToList();
            }
        }
        public class OrderInfo
        {
            public int Date { get; set; }
            public string Time { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public int Brigade { get; set; }
            public string Telefone { get; set; }
            public string Client { get; set; }
        }

        public static List<BrigadeInfo> GetBrigadeInfo()
        {
            using (var db = new ApplicationContext())
            {
                return (from o in db.Order
                        join a in db.Address on o.Address.ID equals a.ID
                        select new BrigadeInfo()

                        {
                            Brigade = o.Brigade.ID,
                            Status = o.Status,
                            Address = a.AddAddress(),
                        }).ToList();
            }
        }
        public class BrigadeInfo
        {
            public int Date { get; set; }
            public string Time { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public int Brigade { get; set; }
        }
    }
    
}
