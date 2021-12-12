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
        private int _br;
        public BrigadeApplications(int br)
        {
            InitializeComponent();
            _br = br;
            AddAplication();
        }
        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(d => d.Brigade == _br);
        }
        private void CheckWait_Checked(object sender, RoutedEventArgs e)
        {
            CheckInProcess.IsChecked = false;
            CheckFinish.IsChecked = false;
            SearchBox.Text = "";
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(e => e.Status == "Ожидает");
        }
        private void CheckWait_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckInProcess.IsChecked && (bool)CheckFinish.IsChecked) return;
            AddAplication();
        }
        private void CheckInProcess_Checked(object sender, RoutedEventArgs e)
        {
            CheckWait.IsChecked = false;
            CheckFinish.IsChecked = false;
            SearchBox.Text = "";
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(e => e.Status == "В процессе");
        }
        private void CheckInProcess_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckWait.IsChecked && (bool)CheckFinish.IsChecked) return;
            AddAplication();
        }
        private void CheckFinish_Checked(object sender, RoutedEventArgs e)
        {
            CheckWait.IsChecked = false;
            CheckInProcess.IsChecked = false;
            SearchBox.Text = "";
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(e => e.Status == "Завершена");
        }
        private void CheckFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((bool)CheckWait.IsChecked && (bool)CheckInProcess.IsChecked) return;
            AddAplication();
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
    }
}
