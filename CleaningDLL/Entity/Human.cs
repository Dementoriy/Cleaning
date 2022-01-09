using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;

namespace CleaningDLL.Entity
{
    public abstract class Human
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }

        public Human()
        {
        }

        public Human(string Surname, string Name, string PhoneNumber)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
        }

        public Human(string Surname, string Name, string MiddleName, string PhoneNumber)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.MiddleName = MiddleName;
            this.PhoneNumber = PhoneNumber;
        }
    }
}
