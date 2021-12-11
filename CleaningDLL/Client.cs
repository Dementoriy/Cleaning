using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL
{
    public class Client //Клиент
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)] public string Surname { get; set; }
        [Required]
        [MaxLength(50)] public string Name { get; set; }
        [MaxLength(50)] public string? MiddleName { get; set; }
        [Required]
        [MaxLength(11)] public string ClientTelefonNumber { get; set; }

        public string AddFIO()
        {
            string str = $"{Surname} {Name.Substring(0, 1)}.";
            if (MiddleName != null) str += $"{MiddleName.Substring(0, 1)}.";
            return str;
        }

        public static List<ClientInfo> GetClientInfo(string Telefon)
        {
            using (var db = new ApplicationContext(ApplicationContext.GetDb()))
            {
                return (from c in db.Client
                        where c.ClientTelefonNumber == Telefon
                        join o in db.Order on c.ID equals o.Client.ID
                        join a in db.Address on o.Address.ID equals a.ID
                        select new ClientInfo()
                        {
                            Surname = c.Surname,
                            Name = c.Name,
                            MiddleName = c.MiddleName,
                            Street = a.Street,
                            HouseNumber = a.HouseNumber,
                            Building = a.Building,
                            Entrance = a.Entrance,
                            Apartment_Number = a.Apartment_Number
                        }).ToList();
            }
        }
        public class ClientInfo
        {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string MiddleName { get; set; }
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Building { get; set; }
            public string Entrance { get; set; }
            public string Apartment_Number { get; set; }
        }

        public static bool proverkaClientTelefon(string ClientTelefonNumber)
        {
        using (var db = new ApplicationContext(ApplicationContext.GetDb()))
            {
                return db.Client.Where(a => a.ClientTelefonNumber == ClientTelefonNumber).Any();
            }
        }
    }
}
