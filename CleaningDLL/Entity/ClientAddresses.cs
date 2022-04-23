using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CleaningDLL.Entity
{
    public class ClientAddresses
    {
        public int ID { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public Client Client { get; set; }
        public string Name { get; set; }

        public ClientAddresses(Address address, Client client, string Name)
        {
            this.Address = address;
            this.Client = client;
            this.Name = Name;
        }

        public ClientAddresses()
        {

        }
    }
}
