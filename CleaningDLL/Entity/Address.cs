using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
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
        public Address()
        {

        }
        public Address(string Street, string HouseNumber, string? Building, string? Entrance, string? Apartment_Number)
        {
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.Building = Building;
            this.Entrance = Entrance;
            this.Apartment_Number = Apartment_Number;
        }
        public string AddAddress()
        {
            string str = $"ул.{Street}, д.{HouseNumber}. ";
            int x = str.Length - 2;
            if (Building != "")
            {
                str = str.Remove(x);
                str += $", к.{Building}, ";
            }
            if (Entrance != "")
            {
                str = str.Remove(x);
                str += $", п.{Entrance}.";
            }
            if (Apartment_Number != "")
            {
                str = str.Remove(x);
                str += $", кв.{Apartment_Number}.";
            }
            return str;
        }
    }
}
