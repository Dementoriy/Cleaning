using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Application.xaml
    /// </summary>
    public partial class Applications : Page
    {
        public Applications()
        {
            InitializeComponent();
            AddAplication();
            SelectedOrderInfo();
        }
        private void CheckWait_Checked(object sender, RoutedEventArgs e)
        {
            CheckInProcess.IsChecked = false;
            CheckFinish.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckWait_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckInProcess.IsChecked && !(bool)CheckFinish.IsChecked)
                SelectedOrderInfo();
        }
        private void CheckInProcess_Checked(object sender, RoutedEventArgs e)
        {
            CheckWait.IsChecked = false;
            CheckFinish.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckInProcess_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckWait.IsChecked && !(bool)CheckFinish.IsChecked)
                SelectedOrderInfo();
        }
        private void CheckFinish_Checked(object sender, RoutedEventArgs e)
        {
            CheckWait.IsChecked = false;
            CheckInProcess.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckWait.IsChecked && !(bool)CheckInProcess.IsChecked)
                SelectedOrderInfo();
        }
        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.GetOrderInfo();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void SelectedOrderInfo()
        {
            List<Order.OrderInfo> listSort = Order.GetOrderInfo();
            if (CheckFinish.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Завершена").ToList();
            }
            else if(CheckInProcess.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "В процессе").ToList();
            }
            else if(CheckWait.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Ожидает").ToList();
            }
            if (DatePickerSearch.Text != "")
            {
                DateTime dt = DatePickerSearch.SelectedDate.Value;
                listSort = listSort.Where(e => e.Date == dt.ToString("d")).ToList();
            }
            if (SearchBox.Text != "")
            {
                listSort = listSort.Where(e => e.Address.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Telefone.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Client.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Brigade.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Date.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Time.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Status.ToLower().Contains(SearchBox.Text.ToLower())
                ).ToList();
            }
            dataGridApplication.ItemsSource = listSort;
        }
        private void DatePickerSearch_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ApplicationsFullInfo applicationsFullInfo = new ApplicationsFullInfo();
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridApplication.SelectedValue;
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder(selectedOrder.ID);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void DelDateEndButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearch.Text != "")
            {
                DatePickerSearch.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }
    }
}
