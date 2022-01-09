using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
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
        [MaxLength(12)] public string EmployeeTelefonNumber { get; set; }
        [Required]
        public virtual Position Position { get; set; }
        [Required]
        public int PositionID { get; set; }
        public virtual Brigade? Brigade { get; set; }
        public int? BrigadeID { get; set; }
        [Required]
        public DateTime Employment_Date { get; set; }
        [MaxLength(50)] public string? Login { get; set; }
        [MaxLength(64)] [MinLength(64)] public string? Password { get; set; }

        public Employee()
        {

        }
        public Employee(string Surname, string Name, string? MiddleName, string PassportData, string EmployeeTelefonNumber, 
            int PositionID, int? BrigadeID, DateTime Employment_Date, string? Login, string? Password)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.PassportData = PassportData;
            this.EmployeeTelefonNumber = EmployeeTelefonNumber;
            this.PositionID = PositionID;
            this.BrigadeID = BrigadeID;
            this.Employment_Date = Employment_Date;
            this.Login = Login;
            this.Password = Password;
        }

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

        public static Employee GetBrigadirByBrigada(int id)
        {
            return db.Employee.Where(a => a.BrigadeID == id && a.Position.ID == 2).FirstOrDefault();
        }
        public static Employee GetEmployee(string Login, string Password)
        {
            return db.Employee.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
        }
        public static Employee GetEmployeeBrigade(int Brigade)
        {
            return db.Employee.Where(a => a.BrigadeID == Brigade).FirstOrDefault();
        }

        
        public static List<EmployeeFullInfo> GetEmployeeFullInfo()
        {
            return (from e in db.Employee
                    join p in db.Position on e.PositionID equals p.ID
                    select new EmployeeFullInfo()

                    {
                        ID = e.ID,
                        Cleaner = e.AddFIO(),
                        Positions = p.NamePosition,
                        WorkExperience = e.Employment_Date.ToString("d"), //(DateTime.Today - e.Employment_Date).ToString("d"),
                        Brigade = e.Brigade.ID,
                        Telefone = e.EmployeeTelefonNumber,
                    }).ToList();
        }
        public class EmployeeFullInfo
        {
            public int ID { get; set; }
            public string Cleaner { get; set; }
            public string Positions { get; set; }
            public string WorkExperience { get; set; }
            public int? Brigade { get; set; }
            public string Telefone { get; set; }
        }
    }
}
