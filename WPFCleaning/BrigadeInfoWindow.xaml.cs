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
    /// Логика взаимодействия для BrigadeInfoWindow.xaml
    /// </summary>
    public partial class BrigadeInfoWindow : Window
    {
        private int _br;
        public BrigadeInfoWindow(int br)
        {
            _br = br;
            InitializeComponent();
            AddAplication();
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

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }
    }
}
