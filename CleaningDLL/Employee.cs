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
        public Brigade? Brigade { get; set; }
        [Required]
        public DateTime Employment_Date { get; set; }
        [MaxLength(50)] public string? Login { get; set; }
        [MaxLength(64)] [MinLength(64)] public string? Password { get; set; }

        //public static string AddFIO(int ID)
        //{
        //    string str = $"{Surname} {Name.Substring(0, 1)}.";
        //    if (MiddleName != null) str += $"{MiddleName.Substring(0, 1)}.";
        //    return str;
        //}

        public static Employee GetEmployee(string Login, string Password)
        {
            using (var db = new ApplicationContext())
            {
                return db.Employee.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
                //return (from e in db.Employee
                //        where e.Login == Login && e.Password == Password
                //        select new Employee()).ToList();
            }
        }

    }
}
