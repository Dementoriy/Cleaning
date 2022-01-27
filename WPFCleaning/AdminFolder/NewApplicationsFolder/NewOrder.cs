using System;
using System.Windows;
using CleaningDLL.Entity;
using CleaningDLL;
//
namespace WPFCleaning.Admin
{
    public static class NewOrder
    {
        public static void AddOrder(NewApplication newApplication, ClientPage clientPage, Employee emp)
        {
            Client client;

            if (Client.ClientByTelefonIsNew(clientPage.Telefon.Text))
            {
                client = new Client(clientPage.Surname.Text, clientPage.Name.Text, clientPage.MiddleName.Text, clientPage.Telefon.Text, false);
            }
            else client = Client.GetClientByTelefon(clientPage.Telefon.Text);

            var address = new Address(clientPage.Street.Text, clientPage.HouseNumber.Text, clientPage.Building.Text, clientPage.Entrance.Text,
                clientPage.Apartment_Number.Text);

            if (newApplication.IsCorrectData())
            {
                string NewDate = (newApplication.DatePicker.Text + " " + newApplication.SelectTime.Text);
                Order order;
                if (DateTime.Parse(NewDate) > DateTime.Now)
                {
                    if (DateTime.Parse(NewDate) > DateTime.Now)
                    {
                        order = new Order(EnumStatus.GetDescription(EnumStatus.Status.wait), client, emp, address,
                            Brigade.GetBrigadeByID(Convert.ToInt32(newApplication.BrigadeBox.Text)), DateTime.Parse(NewDate),
                            Order.GetPriceByString(newApplication.PriceBox.Text), newApplication.approximateTime,
                            newApplication.Comment.Text);

                        Context.Db.Order.Add(order);

                        for (int i = 0; i < 7; i++)
                        {
                            if (newApplication.arrayService[1, i] != 0)
                            {
                                var providedService = new ProvidedService(order, Service.GetServiceById(newApplication.arrayService[0, i]),
                                    newApplication.arrayService[1, i]);

                                Context.Db.ProvidedService.Add(providedService);
                            }
                        }

                        Context.Db.Address.Add(address);
                        Context.Db.SaveChanges();
                        MessageBox.Show("Успешно!");
                        newApplication.ClearNewApplication();
                        clientPage.ClearClientInfo();
                        clientPage.ClearClientTelefone();
                    }
                    else MessageBox.Show("Что-то пошло не так :(");
                }
                else MessageBox.Show("Некорректная дата");
            }
        }
    }
}
