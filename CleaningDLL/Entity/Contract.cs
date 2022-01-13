using System;
using System.ComponentModel.DataAnnotations;

namespace CleaningDLL.Entity
{
    public class Contract //Договор с клиентом
    {
        public int ID { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        [Required]
        public DateTime DateOfContract { get; set; }

        public Contract()
        {

        }
        public Contract(Employee Employee, Client Client, DateTime DateOfContract)
        {
            this.Employee = Employee;
            this.Client = Client;
            this.DateOfContract = DateOfContract;
        }
    }
}
