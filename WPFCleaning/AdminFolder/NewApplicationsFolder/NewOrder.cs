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
        public static void AddOrder(NewApplication newApplication, ClientPage clientPage, Employee emp/*, Client client*/)
        {
            Client client;

            if (Client.ClientByTelefonIsNew(clientPage.Telefon.Text))
            {
                client = new Client(clientPage.Surname.Text, clientPage.Name.Text, clientPage.MiddleName.Text, clientPage.Telefon.Text,
                    false, null, null, null, null);
            }
            else client = Client.GetClientByTelefon(clientPage.Telefon.Text);

            string enteredAddress = "Кировская область, Киров, ";

            if (clientPage.CityDistrict.Text != "" && clientPage.CityDistrict.Text != null)
            {
                enteredAddress += clientPage.CityDistrict.Text + ", ";
            }
            if (clientPage.Settlement.Text != "" && clientPage.Settlement.Text != null)
            {
                enteredAddress += clientPage.Settlement.Text + ", ";
            }
            enteredAddress += $"ул.{clientPage.Street.Text} {clientPage.HouseNumber.Text}. ";
            int x = enteredAddress.Length - 2;
            if (clientPage.Block.Text != "" && clientPage.Block.Text != null )
            {
                enteredAddress = enteredAddress.Remove(x);
                enteredAddress += $", к.{clientPage.Block.Text}, ";
            }
            if (clientPage.ApartmentNumber.Text != "" && clientPage.ApartmentNumber.Text != null)
            {
                enteredAddress = enteredAddress.Remove(x);
                enteredAddress += $", кв.{clientPage.ApartmentNumber.Text}.";
            }
            //"Кировская область, Киров, " + clientPage.CityDistrict.Text + ", " + clientPage.Settlement.Text + ", " 
            //    + clientPage.Street.Text + /*" (" + clientPage.CityDistrict.Text + "), "*/ ", " + clientPage.HouseNumber.Text + ", " + clientPage.Block.Text + ", " + clientPage.ApartmentNumber.Text;

            var token = "24446a45461d9e48f334ed4d55e7ebdd8e66f39f";
            var api = new SuggestClient(token);
            var result =api.SuggestAddress(enteredAddress);

            enteredAddress = enteredAddress.Substring(26);

            if (result.suggestions.Count == 0)
            {
                MessageBox.Show("Адрес не найден");
                return;
            }

            List<string?> addressList = new List<string?>() {result.suggestions[0].data.city_district,
                result.suggestions[0].data.settlement, result.suggestions[0].data.street,
                result.suggestions[0].data.house, result.suggestions[0].data.block,
                result.suggestions[0].data.flat};

            CleaningDLL.Entity.Address address;

            if (CleaningDLL.Entity.Address.CheckAddress(addressList[0], addressList[1],
                addressList[2], addressList[3], addressList[4], addressList[5]))
            {
                RoomType roomType = RoomType.GetRoomTypeByName(newApplication.RoomTypeBox.Text);
                address = new CleaningDLL.Entity.Address(addressList[0], addressList[1], addressList[2], 
                    addressList[3], addressList[4], addressList[5], roomType, "Дом", enteredAddress, true);
                CleaningDLL.Entity.Address.Add(address);
            }
            else address = CleaningDLL.Entity.Address.GetAddress(addressList[0], addressList[1], addressList[2],
                    addressList[3], addressList[4], addressList[5]);

            ClientAddresses clientAddresses;
            if (ClientAddresses.CheckClientAddresses(address, client))
            {
                clientAddresses = new ClientAddresses(address, client);
                ClientAddresses.Add(clientAddresses);
            }
            else clientAddresses = ClientAddresses.GetClientAddresses(address, client);

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

                    Order.Add(order);

                    for (int i = 0; i < 7; i++)
                    {
                        if (newApplication.arrayService[1, i] != 0)
                        {
                            var providedService = new ProvidedService(order, Service.GetServiceById(newApplication.arrayService[0, i]),
                                newApplication.arrayService[1, i]);

                            ProvidedService.Add(providedService);
                            
                        }
                    }

                    Order.Update(order);
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
