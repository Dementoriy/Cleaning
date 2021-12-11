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
        [MaxLength(100)] public string Street { get; set; }
        [Required]
        [MaxLength(10)] public string HouseNumber { get; set; }
        [MaxLength(10)] public string? Building { get; set; }
        [MaxLength(10)] public string? Entrance { get; set; }
        [MaxLength(10)] public string? Apartment_Number { get; set; }
        public string AddAddress()
        {
            string str = $"ул.{Street}, д.{HouseNumber}. ";
            if (Building != null)
            {
                int x = str.Length - 2;
                str = str.Remove(x);
                str += $", {Building}, ";
            }
            if (Apartment_Number != null)
            {
                int x = str.Length - 2;
                str = str.Remove(x);
                str += $", кв.{Apartment_Number}.";
            }
            return str;
        }
    }
}
