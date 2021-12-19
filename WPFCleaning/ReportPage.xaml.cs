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
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
            AddAplication();
            SelectedOrderInfo();
            CheckFinish.IsChecked = true;
        }
        
        public void AddAplication()
        {
            dataGridOrder.ItemsSource = Order.GetOrderInfo();
        }

        private void CheckFinish_Checked(object sender, RoutedEventArgs e)
        {
            CheckCanceled.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckCanceled.IsChecked)
                SelectedOrderInfo();
        }
        private void CheckCanceled_Checked(object sender, RoutedEventArgs e)
        {
            CheckFinish.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckCanceled_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!(bool)CheckFinish.IsChecked)
                SelectedOrderInfo();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private List<Order.OrderInfo> _listSort;

        private void SelectedOrderInfo()
        {
            List<Order.OrderInfo> listSort = Order.GetOrderInfo();
            if (CheckFinish.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Завершена").ToList();
            }
            else if (CheckCanceled.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Отменена").ToList();
            }
            if (DatePickerSearchEnd.Text != "" && DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;
                DateTime dtEnd = DatePickerSearchEnd.SelectedDate.Value;

                if (DatePickerSearchStart.SelectedDate.Value <= DatePickerSearchEnd.SelectedDate.Value)
                    listSort = listSort.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();
                else
                {
                    MessageBox.Show("Дата конца периода больше \n даты начала периода");
                    DatePickerSearchEnd.Text = "";
                }

            }
            if (DatePickerSearchStart.Text == "")
            {
                listSort = listSort.ToList();
            }
            if (DatePickerSearchEnd.Text == "" && DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;

                listSort = listSort.Where(e => DateTime.Parse(e.Date) == dtStart.Date).ToList();
            }
            if (SearchBox.Text != "")
            {
                listSort = listSort.Where(e => e.Address.ToLower().Contains(SearchBox.Text.ToLower())
                || e.FinalPrice.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.ApproximateTime.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Brigade.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Date.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Time.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Status.ToLower().Contains(SearchBox.Text.ToLower())
                ).ToList();
            }
            _listSort = listSort;
            dataGridOrder.ItemsSource = listSort;
        }
        private void DatePickerSearchStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }
        private void DatePickerSearchEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void DelDateStartButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearchStart.Text != "")
            {
                DatePickerSearchStart.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }
        private void DelDateEndButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearchEnd.Text != "")
            {
                DatePickerSearchEnd.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ApplicationsFullInfo applicationsFullInfo = new ApplicationsFullInfo();
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridOrder.SelectedValue;
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder(selectedOrder.ID);
        }

        private void CalculateReport_Click(object sender, RoutedEventArgs e)
        {
            List<Order> orders = new List<Order>();
            int fp = 0;
            int sec = 0;

            foreach (Order.OrderInfo order in _listSort)
            {
                orders.Add(Order.GetOrderById(order.ID));
            }
            foreach (Order order in orders)
            {
                fp += order.FinalPrice;
                sec += order.ApproximateTime;
            }
            KolvoOrderBox.Text = orders.Count().ToString();
            KolvoTimeBox.Text = Order.GetTimeByInt(sec);
            PriceBox.Text = fp.ToString();
        }
    }
}
