using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    public static class NewOrder
    {
        public static void AddOrder(NewApplication newApplication, ClientPage clientPage, Employee emp)
        {
            Client client;

            if (Client.ClientByTelefonIsNew(clientPage.Telefon.Text))
            {
                client = new Client
                {
                    Surname = clientPage.Surname.Text,
                    Name = clientPage.Name.Text,
                    MiddleName = clientPage.MiddleName.Text,
                    ClientTelefonNumber = clientPage.Telefon.Text,
                    IsOldClient = false
                };
            }
            else client = Client.GetClientByTelefon(clientPage.Telefon.Text);

            var address = new Address
            {
                Street = clientPage.Street.Text,
                HouseNumber = clientPage.HouseNumber.Text,
                Building = clientPage.Building.Text,
                Entrance = clientPage.Entrance.Text,
                Apartment_Number = clientPage.Apartment_Number.Text
            };


            if (newApplication.IsCorrectData())
            {
                string NewDate = (newApplication.DatePicker.Text + " " + newApplication.SelectTime.Text);
                Order order;
                if (DateTime.Parse(NewDate) > DateTime.Now)
                {
                    if (DateTime.Parse(NewDate) > DateTime.Now)
                    {
                        order = new Order
                        {
                            Status = EnumStatus.GetDescription(EnumStatus.Status.wait),
                            Client = client,
                            Employee = emp,
                            Address = address,
                            Brigade = Brigade.GetBrigadeByID(Convert.ToInt32(newApplication.BrigadeBox.Text)),
                            Date = DateTime.Parse(NewDate),
                            FinalPrice = Order.GetPriceByString(newApplication.PriceBox.Text),
                            ApproximateTime = newApplication.approximateTime,
                            Comment = newApplication.Comment.Text
                        };
                        Context.Db.Order.Add(order);
                        for (int i = 0; i < 7; i++)
                        {
                            if (newApplication.arrayService[1, i] != 0)
                            {
                                var providedService = new ProvidedService
                                {
                                    Order = order,
                                    Service = Service.GetServiceById(newApplication.arrayService[0, i]),
                                    Amount = newApplication.arrayService[1, i],
                                };
                                Context.Db.ProvidedService.Add(providedService);
                            }
                        }
                        var contract = new Contract
                        {
                            Client = client,
                            Employee = emp,
                            DateOfContract = DateTime.Now
                        };

                        Context.Db.Address.Add(address);
                        Context.Db.Contract.Add(contract);
                        Context.Db.SaveChanges();
                        MessageBox.Show("Успешно!");
                        newApplication.ClearNewApplication();
                        clientPage.ClearClientInfo();
                    }
                    else MessageBox.Show("Что-то пошло не так :(");
                }
                else MessageBox.Show("Некорректная дата");
            }
        }
    }
}
