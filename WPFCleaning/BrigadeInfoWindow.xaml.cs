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
            SelectedDatePicker();
        }
       
        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(d => d.Brigade == _br && d.Status !="Завершена" && d.Date == DatePickerSearch.SelectedDate.Value.ToString("d"));
        }
        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SelectedDatePicker()
        {
            DateTime dt = DatePickerSearch.SelectedDate.Value;
            dataGridApplication.ItemsSource = Order.GetBrigadeInfo().Where(d => d.Brigade == _br && d.Status != "Завершена" && d.Date == DatePickerSearch.SelectedDate.Value.ToString("d"));
        }
        private void DatePickerSearch_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedDatePicker();
        }
    }
}
