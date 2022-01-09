using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CleaningDLL.Entity
{
    public class Client : Human //Клиент
    {
        public int ID { get; set; }
        [Required]
        public bool IsOldClient { get; set; }

        public Client()
        {

        }
        public Client(string Surname, string Name, string MiddleName, string PhoneNumber, bool IsOldClient) : base(Surname, Name, MiddleName, PhoneNumber)
        {
            this.IsOldClient = IsOldClient;
        }

        private static ApplicationContext db = Context.Db;

        public static void ClientIsOld(int id)
        {
            Client oldClient = db.Client.Where(c => c.ID == id).FirstOrDefault();
            oldClient.IsOldClient = true;
        }
        public static Client GetClientByTelefon(string telefon)
        {
            return db.Client.Where(e => e.PhoneNumber == telefon).ToList()[0];
        }
        public static bool ClientByTelefonIsNew(string telefon)
        {
            return !db.Client.Where(e => e.PhoneNumber == telefon).Any();
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
                    where c.PhoneNumber == Telefon
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
        
        public static bool proverkaClientTelefon(string Telefon)
        {
                return db.Client.Where(a => a.PhoneNumber == Telefon).Any();
        }
    }
}
