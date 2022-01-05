﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Order //Заявка
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Status { get; set; }
        [Required]
        public virtual Client Client{ get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        public virtual Brigade Brigade { get; set; }
        public int BrigadeID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int FinalPrice { get; set; }
        public int ApproximateTime { get; set; }
        public string? Comment { get; set; }

        private static ApplicationContext db = Context.Db;

        public static void CheckOrder()
        {
            List<Order> orders = db.Order.Where(o => o.Status == "Ожидает" && o.Date < DateTime.Today).ToList();
            foreach (var d in orders)
            {
                d.Status = "Отменена";
                
            }
            db.SaveChanges();
        }
        public static bool IsOldClient(int clientId)
        {
            List<Order> ordersByClientID = db.Order.Where(o => o.Client.ID == clientId && o.Status == "Завершена").ToList();
            if (ordersByClientID.Count >= 3) return true;
            return false;
        }

        public static Order GetOrderById(int id)
        {
            return db.Order.Where(e => e.ID == id).FirstOrDefault();
        }

        public static List<OrderInfo> GetOrderInfo()
        {
            return (from o in db.Order
                    join a in db.Address on o.Address.ID equals a.ID
                    select new OrderInfo()

                    {
                        ID = o.ID,
                        Time = o.Date.ToString("t"),
                        Date = o.Date.ToString("d"),
                        Brigade = o.Brigade.ID,
                        Status = o.Status,
                        Client = o.Client.AddFIO(),
                        Address = a.AddAddress(),
                        Telefone = o.Client.ClientTelefonNumber,
                        FinalPrice = o.FinalPrice,
                        ApproximateTime = (GetTimeByInt(o.ApproximateTime)).ToString()
                    }).ToList();
        }
        public class OrderInfo
        {
            public int ID { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string Address { get; set; }
            public string Status { get; set; }
            public int Brigade { get; set; }
            public string Telefone { get; set; }
            public string Client { get; set; }
            public string ApproximateTime { get; set; }
            public int FinalPrice { get; set; }
        }

        public static string GetTimeByInt(int t)
        {
            t = t / 60;
            int h = t / 60;
            int m = t % 60;
            return (h + " ч. " + m + "мин.");
        }
    }
}
