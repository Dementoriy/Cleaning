using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using System.Linq;
using CleaningDLL;
using WPFCleaning.AdminFolder.ApplicationsFolder;

namespace WPFCleaning.Admin
{
    /// <summary>
    /// Класс реализующий отображение полной информации о заявке
    /// </summary>
    public partial class ApplicationsFullInfo : Window
    {
        private Applications _applications;
        Order order;
        public int idService;
        public decimal finalPrice = 0;
        public int approximateTime = 0;

        public ApplicationsFullInfo(int id,  Applications a)
        {
            order = Order.GetOrderById(id); //выбранная заявка
            _applications = a; //страница вызова
            InitializeComponent();
            WindowState = WindowState.Maximized;
            GetStatus();
            StatusBox.IsEnabled = false;
            SaveUpdatedOrder.IsEnabled = false;
            BrigadeBox.IsEnabled = false;
            DatePicker.IsEnabled = false;
            SelectTime.IsEnabled = false;
            BtnBrigadeInfo.IsEnabled = false;
            Comment.IsEnabled = false;
            UpdateOrder.IsEnabled = true;
        }
        public void AddSelectedOrder()
        {

            Telefon.Text = order.Client.PhoneNumber;
            Surname.Text = order.Client.Surname;
            Name.Text = order.Client.Name;
            if (order.Client.MiddleName != null) MiddleName.Text = order.Client.MiddleName;

            if (order.Client.IsOldClient) CheckOldClient.IsChecked = true;

            //CityDistrict.Text = order.Address.CityDistrict;
            Settlement.Text = order.Address.Settlement;
            Street.Text = order.Address.Street;
            HouseNumber.Text = order.Address.HouseNumber;
            Block.Text = order.Address.Block;
            ApartmentNumber.Text = order.Address.ApartmentNumber;

            PriceBox.Text = Order.GetPriceByInt(order.FinalPrice);
            ApproximateTime.Text = Order.GetTimeByInt(order.ApproximateTime);
            StatusBox.Text = order.Status;

            DatePicker.Text = order.Date.ToString("d");
            SelectTime.Text = order.Date.ToString("t");
            if(!int.TryParse(SelectTime.Text.Substring(0,2),out int i))
            {
                SelectTime.Text = "0" + SelectTime.Text;
            }
            BrigadeBox.Text = order.BrigadeID.ToString();

            Employee brigadir = Employee.GetBrigadirByBrigada(order.BrigadeID);

            BrigadirTelefon.Text = brigadir.PhoneNumber;
            BrigadirSurname.Text = brigadir.Surname;
            BrigadirName.Text = brigadir.Name;
            BrigadirMiddleName.Text = brigadir.MiddleName;
            BrigadeNumber.Text = order.BrigadeID.ToString();

            Comment.Text = order.Comment;

            CheckService.GetCheckedService(order.ID, this);
        }

        private void LockSelection(object sender, EventArgs e)
        {
            if (sender is CheckBox)
                ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
        }

        public void SaveUpdatedOrder_Click(object sender, RoutedEventArgs e)
        {
            string NewDate = (DatePicker.Text + " " + SelectTime.Text);
            if (DateTime.Parse(NewDate) > DateTime.Now)
            {
                order.Status = StatusBox.Text;
                order.Brigade = Brigade.GetBrigadeByID(Convert.ToInt32(BrigadeBox.Text));
                order.Date = DateTime.Parse(NewDate);
                order.FinalPrice = Order.GetPriceByString(PriceBox.Text); 
                order.Comment = Comment.Text;

                Context.Db.SaveChanges();
                MessageBox.Show("Заявка изменена успешно!");
                if(_applications != null)
                    _applications.SelectedOrderInfo();
                UpdateOrder.IsEnabled = true;
                this.Close();
            }
            else MessageBox.Show("Некорректная дата");
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
                BrigadeBox.IsEnabled = true;
                DatePicker.IsEnabled = true;
                SelectTime.IsEnabled = true;
                BtnBrigadeInfo.IsEnabled = true;
                Comment.IsEnabled = true;
                UpdateOrder.IsEnabled = false;
            }
        }
        public void GetStatus()
        {
            var statuses = EnumStatus.GetStatusesForAdmin(order.Status);
            StatusBox.ItemsSource = statuses;
        }

        private void BtnBrigadeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (BrigadeBox.SelectedIndex != -1)
            {
                BrigadeInfoWindow brigadeInfoWindow = new BrigadeInfoWindow(Employee.GetEmployeeBrigade(int.Parse(BrigadeBox.Text)));
                brigadeInfoWindow.Show();
            }
            else MessageBox.Show("Выберите бригаду");
        }

        private void SelectTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }

        private void SelectTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChangeOrder.TextChanged(this);
        }

        private void SelectTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ChangeOrder.PreviewTextInput(this, e);
        }
    }
}
