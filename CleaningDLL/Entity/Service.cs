﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Service //Услуга
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)] public string Service_Name { get; set; }
        [Required]
        [MaxLength(200)] public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual InventoryType? Inventory_Type { get; set; }
        [Required]
        public int Time { get; set; }

        private static ApplicationContext db = Context.Db;

        public static int GetIdService(string str)
        {
            int idService;
            Service service = db.Service.Where(s => s.Service_Name == str).FirstOrDefault();
            idService = service.ID;
            return idService;
        }

        public static Service GetServiceById(int idService)
        {
            return db.Service.Where(s => s.ID == idService).FirstOrDefault();
        }
    }
}