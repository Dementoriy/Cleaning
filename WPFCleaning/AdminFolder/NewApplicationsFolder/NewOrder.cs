using System;
using System.Windows;
using CleaningDLL.Entity;
using CleaningDLL;
using Dadata;
using Dadata.Model;
using System.Collections.Generic;

//
namespace WPFCleaning.Admin
{
    public static class NewOrder
    {
        public static async void AddOrder(NewApplication newApplication, ClientPage clientPage, Employee emp)
        {
            Client client;

            if (Client.ClientByTelefonIsNew(clientPage.Telefon.Text))
            {
                client = new Client(clientPage.Surname.Text, clientPage.Name.Text, clientPage.MiddleName.Text, clientPage.Telefon.Text,
                    false, null, null, null);
            }
            else client = Client.GetClientByTelefon(clientPage.Telefon.Text);

            string enteredAddress = "Киров, " + clientPage.CityDistrict.Text + ", " + clientPage.Settlement.Text + ", " + clientPage.Street.Text + ", "
                    + clientPage.HouseNumber.Text + ", " + clientPage.Block.Text + ", " + clientPage.ApartmentNumber.Text;

            var token = "24446a45461d9e48f334ed4d55e7ebdd8e66f39f";
            var api = new SuggestClientAsync(token);
            var result = await api.SuggestAddress(enteredAddress);

            //Проверки!
            List<string?> addressList = new List<string?>() {/*result.suggestions[0].data.city_district.ToString(),*/
                result.suggestions[0].data.settlement.ToString(), result.suggestions[0].data.street.ToString(),
                result.suggestions[0].data.house.ToString(), result.suggestions[0].data.block.ToString(),
                result.suggestions[0].data.flat.ToString()};

            for(int i = 0; i < addressList.Count; i++)
            {
                if (addressList[i] == null)
                {
                    addressList[i] = "";
                }
            }

            //var address = new CleaningDLL.Entity.Address(addressList[0], addressList[1],
            //    addressList[2], addressList[3], addressList[4], addressList[5]);

            CleaningDLL.Entity.Address address;

            if (CleaningDLL.Entity.Address.CheckAddress(addressList[0], addressList[1],
                addressList[2], addressList[3], addressList[4]/*, addressList[5]*/))
            {
                address = new CleaningDLL.Entity.Address(addressList[0], addressList[1], addressList[2], 
                    addressList[3], addressList[4]/*, addressList[5]*/);
            }
            else address = CleaningDLL.Entity.Address.GetAddress(addressList[0], addressList[1], addressList[2],
                    addressList[3], addressList[4]/*, addressList[5]*/);


            var ClientAddresses = new ClientAddresses(address, client, "Дом");
            Context.Db.ClientAddresses.Add(ClientAddresses);

            if (newApplication.IsCorrectData())
            {
                string NewDate = (newApplication.DatePicker.Text + " " + newApplication.SelectTime.Text);
                Order order;
                if (DateTime.Parse(NewDate) > DateTime.Now)
                {
                    order = new Order(EnumStatus.GetDescription(EnumStatus.Status.scheduledDeparture), client, emp, address,
                        Brigade.GetBrigadeByID(Convert.ToInt32(newApplication.BrigadeBox.Text)), DateTime.Parse(NewDate),
                        Order.GetPriceByString(newApplication.PriceBox.Text), newApplication.approximateTime,
                        newApplication.Comment.Text, null);

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
                else MessageBox.Show("Некорректная дата");
            }
        }
    }
}
