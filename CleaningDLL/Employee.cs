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
        public string FirstName { get; set; }
        [Required]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string PassportData { get; set; }
        [Required]
        public string EmployeeTelefonNumber { get; set; }
        public Position Position { get; set; }
        public DateTime Employment_Date { get; set; }
    }
}
