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
            SelectedDatePicker();
        }
        private void CheckWait_Checked(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearch.Text == "")
            {
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Ожидает");
            }
            else
            {
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Ожидает" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d"));
            }
        }
        private void CheckWait_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckInProcess.IsChecked && (bool)CheckFinish.IsChecked) return;
            AddAplication();
            if (DatePickerSearch.Text != "")
            {
                SelectedDatePicker();
            }
        }
        private void CheckInProcess_Checked(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearch.Text == "")
            {
                CheckWait.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "В процессе");
            }
            else
            {
                CheckWait.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "В процессе" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d"));
            }
        }
        private void CheckInProcess_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckWait.IsChecked && (bool)CheckFinish.IsChecked) return;
            AddAplication();
            if (DatePickerSearch.Text != "")
            {
                SelectedDatePicker();
            }
        }
        private void CheckFinish_Checked(object sender, RoutedEventArgs e)
        {
            if(DatePickerSearch.Text == "")
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Завершена");
            }
            else
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Завершена" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d"));
            }
        }
        private void CheckFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckWait.IsChecked && (bool)CheckInProcess.IsChecked) return;
            AddAplication();
            if (DatePickerSearch.Text != "")
            {
                SelectedDatePicker();
            }
        }
        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.GetOrderInfo();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                //dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Number == int.Parse(SearchBox.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено не число!");
                AddAplication();
            }
        }

        private void SelectedDatePicker()
        {
            DateTime dt = DatePickerSearch.SelectedDate.Value;
            dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Date == dt.ToString("d"));
        }
        private void DatePickerSearch_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedDatePicker();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ApplicationsFullInfo applicationsFullInfo = new ApplicationsFullInfo();
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridApplication.SelectedValue;
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder(selectedOrder.ID);
        }
    }
}
