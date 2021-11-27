using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Contract //Договор с клиентом
    {
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public Client Client { get; set; }
        public DateTime Date_Of_Contract { get; set; }
    }
}
