using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void ClientSearch_Click(object sender, RoutedEventArgs e)
        {
            ClearClientInfo();
            if (Client.proverkaClientTelefon(Telefon.Text))
            {
                var tmp = Client.GetClientInfo(Telefon.Text).ToArray().Length - 1;
                Surname.Text = Client.GetClientInfo(Telefon.Text)[0].Surname;
                Name.Text = Client.GetClientInfo(Telefon.Text)[0].Name;
                MiddleName.Text = Client.GetClientInfo(Telefon.Text)[0].MiddleName;
                Street.Text = Client.GetClientInfo(Telefon.Text)[tmp].Street;
                HouseNumber.Text = Client.GetClientInfo(Telefon.Text)[tmp].HouseNumber;
                Building.Text = Client.GetClientInfo(Telefon.Text)[tmp].Building;
                Entrance.Text = Client.GetClientInfo(Telefon.Text)[tmp].Entrance;
                Apartment_Number.Text = Client.GetClientInfo(Telefon.Text)[tmp].Apartment_Number;
            }
            else MessageBox.Show("Клиента нет в БД");
        }

        private void ClearClientInfo()
        {
            Surname.Text = "";
            Name.Text = "";
            MiddleName.Text = "";
            Street.Text = "";
            HouseNumber.Text = "";
            Building.Text = "";
            Entrance.Text = "";
            Apartment_Number.Text = "";
        }

        public void NextPageNewOrder_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow.GoNewApplication();
        }
    }
}
