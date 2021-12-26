using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaningDLL.Entity
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
        [MaxLength(12)] public string ClientTelefonNumber { get; set; }
        [Required]
        public bool IsOldClient { get; set; }

        private static ApplicationContext db = Context.Db;


        public static Client GetClientByTelefon(string telefon)
        {
            return db.Client.Where(e => e.ClientTelefonNumber == telefon).ToList()[0];
        }
        public static bool ClientByTelefonIsNew(string telefon)
        {
            try
            {
                Client client = db.Client.Where(e => e.ClientTelefonNumber == telefon).ToList()[0];
                return false;
            }
            catch
            {
                return true;
            }
        }
        public string AddFIO()
        {
            string str = $"{Surname} {Name.Substring(0, 1)}.";
            if (MiddleName != "") str += $"{MiddleName.Substring(0, 1)}.";
            return str;
        }

        public static List<ClientInfo> GetClientInfo(string Telefon) //Клиент не связан с адресом. В листе хранится клиент с разными адресами
        {
            return (from c in db.Client
                    where c.ClientTelefonNumber == Telefon
                    join o in db.Order on c.ID equals o.Client.ID
                    join a in db.Address on o.Address.ID equals a.ID
                    select new ClientInfo()
                    {
                        ID = c.ID,
                        Surname = c.Surname,
                        Name = c.Name,
                        MiddleName = c.MiddleName,
                        Street = a.Street,
                        HouseNumber = a.HouseNumber,
                        Building = a.Building,
                        Entrance = a.Entrance,
                        Apartment_Number = a.Apartment_Number,
                        IsOldClient = c.IsOldClient
                    }).ToList();
        }
        public class ClientInfo
        {
            public int ID { get; set; }
            public string Surname { get; set; }
            public string Name { get; set; }
            public string MiddleName { get; set; }
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Building { get; set; }
            public string Entrance { get; set; }
            public string Apartment_Number { get; set; }
            public bool IsOldClient { get; set; }
        }
        
        public static bool proverkaClientTelefon(string ClientTelefonNumber)
        {
                return db.Client.Where(a => a.ClientTelefonNumber == ClientTelefonNumber).Any();
        }
    }
}
