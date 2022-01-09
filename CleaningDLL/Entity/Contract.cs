using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
{
    public class Contract //Договор с клиентом
    {
        public int ID { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        public int ClientID { get; set; }
        [Required]
        public DateTime DateOfContract { get; set; }

        public Contract()
        {

        }
        public Contract(int EmployeeID, int ClientID, DateTime DateOfContract)
        {
            this.EmployeeID = EmployeeID;
            this.ClientID = ClientID;
            this.DateOfContract = DateOfContract;
        }
    }
}
