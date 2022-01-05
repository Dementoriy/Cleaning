using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using System.Linq;

namespace WPFCleaning.Admin
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsFullInfo.xaml
    /// </summary>
    public partial class ApplicationsFullInfo : Window
    {
        public ApplicationsFullInfo()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void AddSelectedOrder(int id)
        {
            Order order = Order.GetOrderById(id);

            Telefon.Text = order.Client.ClientTelefonNumber;
            Surname.Text = order.Client.Surname;
            Name.Text = order.Client.Name;
            if (order.Client.MiddleName != null)
                MiddleName.Text = order.Client.MiddleName;
            //CheckOldClient = ClientPage

            Street.Text = order.Address.Street;
            HouseNumber.Text = order.Address.HouseNumber;
            Building.Text = order.Address.Building;
            Entrance.Text = order.Address.Entrance;
            Apartment_Number.Text = order.Address.Apartment_Number;

            PriceBox.Text = order.FinalPrice.ToString();
            ApproximateTime.Text = Order.GetTimeByInt(order.ApproximateTime);
            StatusBox.Text = order.Status;

            Employee brigadir = Employee.GetBrigadirByBrigada(order.BrigadeID);

            BrigadirTelefon.Text = brigadir.EmployeeTelefonNumber;
            BrigadirSurname.Text = brigadir.Surname;
            BrigadirName.Text = brigadir.Name;
            BrigadirMiddleName.Text = brigadir.MiddleName;
            BrigadeNumber.Text = order.BrigadeID.ToString();

            Comment.Text = order.Comment;

            List<ProvidedService> pvs = ProvidedService.GetPSByOrder(order.ID);

            Sqare.Text = pvs.Where(a => a.ServiceID < 5).FirstOrDefault().Amount.ToString();

            foreach (var p in pvs)
            {
                if (p.ServiceID == 1) CheckExpressClean.IsChecked = true;
                if (p.ServiceID == 2) CheckGeneralClean.IsChecked = true;
                if (p.ServiceID == 3) CheckBuildingClean.IsChecked = true;
                if (p.ServiceID == 4) CheckOfficeClean.IsChecked = true;
                if (p.ServiceID == 5 || p.ServiceID == 6)
                {
                    WindowClean.IsChecked = true;
                    KolvoWindow.Text = pvs.Where(a => a.ServiceID == 5).FirstOrDefault().Amount.ToString();
                    KolvoDoor.Text = pvs.Where(a => a.ServiceID == 6).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 7 || p.ServiceID == 8 || p.ServiceID == 9)
                {
                    ChemistryClean.IsChecked = true;
                    KolvoSofa.Text = pvs.Where(a => a.ServiceID == 7).FirstOrDefault().Amount.ToString();
                    KolvoArmcheir.Text = pvs.Where(a => a.ServiceID == 8).FirstOrDefault().Amount.ToString();
                    KolvoCarpet.Text = pvs.Where(a => a.ServiceID == 9).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 10)
                {
                    Dezinfection.IsChecked = true;
                    KolvoDezinfection.Text = pvs.Where(a => a.ServiceID == 10).FirstOrDefault().Amount.ToString();
                }
            }
        }

        private void CheckExpressClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckGeneralClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBuildingClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckOfficeClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void WindowClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void KolvoService_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void KolvoService_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CheckService_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void WindowClean_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxSquare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBoxSquare_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxSquare_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrigadeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
