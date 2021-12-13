using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Employee //Сотрудник
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Surname { get; set; }
        [Required]
        [MaxLength(50)] public string Name { get; set; }
        [MaxLength(50)] public string? MiddleName { get; set; }
        [Required]
        [MaxLength(10)] public string PassportData { get; set; }
        [Required]
        [MaxLength(11)] public string EmployeeTelefonNumber { get; set; }
        [Required]
        public Position Position { get; set; }
        [Required]
        public int PositionID { get; set; }
        public Brigade? Brigade { get; set; }
        public int? BrigadeID { get; set; }
        [Required]
        public DateTime Employment_Date { get; set; }
        [MaxLength(50)] public string? Login { get; set; }
        [MaxLength(64)] [MinLength(64)] public string? Password { get; set; }

        public String AddFIO()
        {
            string str = $"{Surname} {Name.Substring(0, 1)}.";
            if (MiddleName != null) str += $"{MiddleName.Substring(0, 1)}.";
            return str;
        }
        public class EmployeeInfo
        {
            public int Surname { get; set; }
            public string Name { get; set; }
            public string MiddleName { get; set; }
        }

        private static ApplicationContext db = Context.Db;

        public static Employee GetEmployee(string Login, string Password)
        {
            return db.Employee.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
        }

        public static void Add (Employee employee)
        {
            db.Employee.Add(employee);
            db.SaveChanges();
        }
        public static Employee GetEmployeeBrigade(int Brigade)
        {
            return db.Employee.Where(a => a.BrigadeID == Brigade).FirstOrDefault();
        }
    }
}
