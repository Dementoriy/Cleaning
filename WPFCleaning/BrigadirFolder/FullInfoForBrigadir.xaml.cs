using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CleaningDLL;
using CleaningDLL.Entity;
using System.Linq;

namespace WPFCleaning.Brigadir
{
    /// <summary>
    /// Логика взаимодействия для FullInfoForBrigadir.xaml
    /// </summary>
    public partial class FullInfoForBrigadir : Window
    {
        Order order;
        private BrigadeApplications _brigadeApplications;
        public FullInfoForBrigadir(int id, BrigadeApplications ba)
        {
            InitializeComponent();
            _brigadeApplications = ba;
            WindowState = WindowState.Maximized;
            order = Order.GetOrderById(id);
            GetStatus();
            StatusBox.IsEnabled = false;
            SaveUpdatedOrder.IsEnabled = false;
            UpdateOrder.IsEnabled = true;
        }

        public void AddSelectedOrder(int id)
        {
            Telefon.Text = order.Client.PhoneNumber;
            Surname.Text = order.Client.Surname;
            Name.Text = order.Client.Name;
            if (order.Client.MiddleName != null) MiddleName.Text = order.Client.MiddleName;

            if (order.Client.IsOldClient) CheckOldClient.IsChecked = true;

            CityDistrict.Text = order.Address.CityDistrict;
            Settlement.Text = order.Address.Settlement;
            Street.Text = order.Address.Street;
            HouseNumber.Text = order.Address.HouseNumber;
            Block.Text = order.Address.Block;
            ApartmentNumber.Text = order.Address.ApartmentNumber;

            PriceBox.Text = Order.GetPriceByInt(order.FinalPrice);
            ApproximateTime.Text = Order.GetTimeByInt(order.ApproximateTime);
            StatusBox.Text = order.Status;

            Employee brigadir = Employee.GetBrigadirByBrigada(order.BrigadeID);

            BrigadirTelefon.Text = brigadir.PhoneNumber;
            BrigadirSurname.Text = brigadir.Surname;
            BrigadirName.Text = brigadir.Name;
            BrigadirMiddleName.Text = brigadir.MiddleName;
            BrigadeNumber.Text = order.BrigadeID.ToString();

            Comment.Text = order.Comment;

            List<ProvidedService> pvs = ProvidedService.GetPSByOrder(order.ID);

            foreach (var p in pvs)
            {
                if (p.ServiceID == 1)
                {
                    CheckExpressClean.IsChecked = true;
                    Sqare.Text = p.Amount.ToString();
                }
                if (p.ServiceID == 2)
                {
                    CheckGeneralClean.IsChecked = true;
                    Sqare.Text = p.Amount.ToString();
                }
                if (p.ServiceID == 3)
                {
                    CheckBuildingClean.IsChecked = true;
                    Sqare.Text = p.Amount.ToString();
                }
                if (p.ServiceID == 4)
                {
                    CheckOfficeClean.IsChecked = true;
                    Sqare.Text = p.Amount.ToString();
                }
                if (p.ServiceID == 5)
                {
                    WindowClean.IsChecked = true;
                    KolvoWindow.Text = pvs.Where(a => a.ServiceID == 5).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 6)
                {
                    KolvoDoor.Text = pvs.Where(a => a.ServiceID == 6).FirstOrDefault().Amount.ToString();
                    WindowClean.IsChecked = true;
                }
                if (p.ServiceID == 7)
                {
                    ChemistryClean.IsChecked = true;
                    KolvoSofa.Text = pvs.Where(a => a.ServiceID == 7).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 8)
                {
                    ChemistryClean.IsChecked = true;
                    KolvoArmcheir.Text = pvs.Where(a => a.ServiceID == 8).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 9)
                {
                    ChemistryClean.IsChecked = true;
                    KolvoCarpet.Text = pvs.Where(a => a.ServiceID == 9).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 10)
                {
                    Dezinfection.IsChecked = true;
                    KolvoDezinfection.Text = pvs.Where(a => a.ServiceID == 10).FirstOrDefault().Amount.ToString();
                }
            }
        }

        private void LockSelection(object sender, EventArgs e)
        {
            if (sender is CheckBox)
                ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
        }

        public void SaveUpdatedOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            order.Status = StatusBox.Text;
            Context.Db.SaveChanges();
            MessageBox.Show("Статус заявки изменен успешно!");
            _brigadeApplications.SelectedOrderInfo();
            UpdateOrder.IsEnabled = true;
            this.Close();
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (StatusBox.Text == "Завершена" || StatusBox.Text == "Отменена")
            {
                MessageBox.Show("Статус заявки изменить нельзя!");
            }
            else
            {
                StatusBox.IsEnabled = true;
                SaveUpdatedOrder.IsEnabled = true;
                UpdateOrder.IsEnabled = false;
            }    
        }
        public void GetStatus()
        {
            var statuses = EnumStatus.GetStatusesForBrigadir(order.Status);
            StatusBox.ItemsSource = statuses;
        }
    }
}