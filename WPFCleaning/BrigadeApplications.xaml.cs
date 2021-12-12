using System;
using System.Windows;
using System.Windows.Controls;
using CleaningDLL;
using System.Linq;

namespace WPFCleaning
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
            SelectedDatePicker();
        }
        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(d => d.Brigade == _br.BrigadeID);
        }
        private void CheckWait_Checked(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearch.Text == "")
            {
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Ожидает" && e.Brigade == _br.BrigadeID);
            }
            else
            {
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Ожидает" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d") && e.Brigade == _br.BrigadeID);
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
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "В процессе" && e.Brigade == _br.BrigadeID);
            }
            else
            {
                CheckWait.IsChecked = false;
                CheckFinish.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "В процессе" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d") && e.Brigade == _br.BrigadeID);
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
            if (DatePickerSearch.Text == "")
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Завершена" && e.Brigade == _br.BrigadeID);
            }
            else
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                SearchBox.Text = "";
                dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Status == "Завершена" && e.Date == DatePickerSearch.SelectedDate.Value.ToString("d") && e.Brigade == _br.BrigadeID);
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
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                CheckWait.IsChecked = false;
                CheckInProcess.IsChecked = false;
                CheckFinish.IsChecked = false;
                //dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(e => e.Number == int.Parse(SearchBox.Text));
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
            dataGridApplication.ItemsSource = Order.GetOrderInfo().Where(e => e.Date == dt.ToString("d") && e.Brigade == _br.BrigadeID);
        }
        private void DatePickerSearch_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedDatePicker();
        }
    }
}
