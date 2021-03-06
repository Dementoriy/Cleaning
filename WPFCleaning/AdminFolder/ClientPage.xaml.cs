using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CleaningDLL;
using CleaningDLL.Entity;
using Xceed.Wpf.Toolkit;

namespace WPFCleaning.Admin
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

        private static ApplicationContext db = Context.Db;
        private void ClientSearch_Click(object sender, RoutedEventArgs e)
        {
            if (Client.proverkaClientTelefon(Telefon.Text))
            {
                var lastAddress = Client.GetClientInfo(Telefon.Text).ToArray().Length - 1;
                if(lastAddress == -1)
                {
                    Client client = Client.GetClientByTelefon(Telefon.Text);

                    Surname.Text = client.Surname;
                    Name.Text = client.Name;
                    MiddleName.Text = client.MiddleName;
                    window.newApplication.RoomTypeBox.SelectedItem = "Квартира";
                    if (Order.IsOldClienCheck(client.ID))
                    {
                        CheckOldClient.IsChecked = true;
                        Client.ClientIsOld(client.ID);
                        db.SaveChanges();
                    }
                    else CheckOldClient.IsChecked = false;
                }
                else
                {
                    Client.ClientInfo client = Client.GetClientInfo(Telefon.Text)[lastAddress];

                    Surname.Text = client.Surname;
                    Name.Text = client.Name;
                    MiddleName.Text = client.MiddleName;
                    CityDistrict.Text = client.CityDistrict;
                    Settlement.Text = client.Settlement;
                    Street.Text = client.Street;
                    HouseNumber.Text = client.HouseNumber;
                    Block.Text = client.Block;
                    ApartmentNumber.Text = client.ApartmentNumber;
                    window.newApplication.RoomTypeBox.SelectedItem = client.RoomType;
                    if (Order.IsOldClienCheck(client.ID))
                    {
                        CheckOldClient.IsChecked = true;
                        Client.ClientIsOld(client.ID);
                        db.SaveChanges();
                    }
                    else CheckOldClient.IsChecked = false;
                }
                
            }
            else
            {
                System.Windows.MessageBox.Show("Клиента нет в БД");
                ClearClientInfo();
            }
                
        }
        public void ClearClientTelefone()
        {
            Telefon.Text = "";
        }
        public void ClearClientInfo()
        {
            Surname.Text = "";
            Name.Text = "";
            MiddleName.Text = "";
            CityDistrict.Text = "";
            Settlement.Text = "";
            Street.Text = "";
            HouseNumber.Text = "";
            Block.Text = "";
            ApartmentNumber.Text = "";
            CheckOldClient.IsChecked = false;
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
                Telefon.Text = "+7";
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

        private void CheckOldClient_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
                ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
        }
    }
}
