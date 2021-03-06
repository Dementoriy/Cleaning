using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CleaningDLL.Entity
{
    public class Contract
    {
        public int ID { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public DateTime DateOfContract { get; set; }
        private static ApplicationContext db = Context.Db;

        public Contract()
        {

        }
        public Contract(Employee Employee, Client Client, DateTime DateOfContract)
        {
            this.Employee = Employee;
            this.Client = Client;
            this.DateOfContract = DateOfContract;
        }
        public static Contract GetContractById(int id)
        {

            try
            {
                return db.Contract.FirstOrDefault(c => c.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
