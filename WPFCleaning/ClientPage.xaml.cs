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
using Xceed.Wpf.Toolkit;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage(MainWindow window)
        {
            this.window = window;
            InitializeComponent();

        }
        private MainWindow window;

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
            else System.Windows.MessageBox.Show("Клиента нет в БД");
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
            this.window.View.Navigate(window.newApplication);
            window.ClientBtn.BorderBrush = Brushes.Black;
            window.NewOrderBtn.BorderBrush = Brushes.White;
            window.OrderBtn.BorderBrush = Brushes.Black;
        }

        private void Telefon_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string t = Telefon.Text;
            if (t.Length == 0)
            {
                Telefon.Text = "+";
                Telefon.SelectionStart = Telefon.Text.Length; //коретка в конец строки
            }
            if (t.Length >= 12)
            {
                e.Handled = true; // отклоняем ввод
            }
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }
        private void Telefon_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }
    }
}
