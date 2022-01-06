﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Position //Должность
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string NamePosition { get; set; }
        [Required]
        [MaxLength(150)] public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        private static ApplicationContext db = Context.Db;
        public Position()
        {
            Employees = new List<Employee>();
        }
        public static Position GetByID(int id)
        {
            return db.Position.Where(d => d.ID == id).FirstOrDefault();
        }
    }
}