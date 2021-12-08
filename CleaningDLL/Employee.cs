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
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string PassportData { get; set; }
        [Required]
        public string EmployeeTelefonNumber { get; set; }
        public Position Position { get; set; }
        public DateTime Employment_Date { get; set; }
        [MaxLength(50)] public string Login { get; set; }
        [MaxLength(64)] [MinLength(64)] public string Password { get; set; }

        public static bool proverka(string Login, string Password)
        {
            using (var db = new ApplicationContext())
            {
                return db.Employee.Where(a => a.Login == Login && a.Password == Password).Any();
            }
        }
    }
}
