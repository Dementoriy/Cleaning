using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using CleaningDLL.Entity;

namespace WPFCleaning.Brigadir
{
    /// <summary>
    /// Логика взаимодействия для BrigadeApplications.xaml
    /// </summary>
    public partial class BrigadeApplications : Page
    {
        private Employee _br;
        public BrigadeApplications(Employee br)
        {
            _br = br;
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

        public void SelectedOrderInfo()
        {
            SelectedOrderInformations.GetSelectOrderInfo(this, _br);
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
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridApplication.SelectedValue;
            FullInfoForBrigadir applicationsFullInfo = new FullInfoForBrigadir(selectedOrder.ID, this);
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder(selectedOrder.ID);
        }
    }
}
