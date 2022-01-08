using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using CleaningDLL.Entity;

namespace WPFCleaning.Admin
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
            if (!CheckInProcess.IsChecked.GetValueOrDefault() && !CheckFinish.IsChecked.GetValueOrDefault())
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
            if (!CheckWait.IsChecked.GetValueOrDefault() && !CheckFinish.IsChecked.GetValueOrDefault())
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
            if (!CheckWait.IsChecked.GetValueOrDefault() && !CheckInProcess.IsChecked.GetValueOrDefault())
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

        public void SelectedOrderInfo()
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
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridApplication.SelectedValue;
            ApplicationsFullInfo applicationsFullInfo = new ApplicationsFullInfo(selectedOrder.ID, this);
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void DelDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearch.Text != "")
            {
                DatePickerSearch.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }

        private void DatePickerSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text != ".")
            {
                e.Handled = true; // отклоняем ввод
            }
        }
    }
}
