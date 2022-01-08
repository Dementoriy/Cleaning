using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CleaningDLL.Entity;

namespace WPFCleaning.Admin
{
    /// <summary>
    /// Логика взаимодействия для BrigadeInfoWindow.xaml
    /// </summary>
    public partial class BrigadeInfoWindow : Window
    {
        private Employee _br;
        public BrigadeInfoWindow(Employee br)
        {
            _br = br;
            InitializeComponent();
            SelectedOrderInfo();
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
            dataGridApplication.ItemsSource = listSort.Where(d => d.Brigade == _br.BrigadeID && d.Status != "Завершена");
        }
        private void DatePickerSearch_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void DatePickerSearch_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text != ".")
            {
                e.Handled = true; // отклоняем ввод
            }
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
    }
}
