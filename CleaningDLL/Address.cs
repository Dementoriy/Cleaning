using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Address //Адрес
    {
        public int ID { get; set; }
        [Required]
        public string Streat { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string Building { get; set; }
        public string Entrance { get; set; }
        public string Apartment_Number { get; set; }

    }
}
