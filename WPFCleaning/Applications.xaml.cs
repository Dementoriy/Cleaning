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
        }
        private void CheckActive_Checked(object sender, RoutedEventArgs e) => CheckInAssembly.IsChecked = false;
        private void CheckInAssembly_Checked(object sender, RoutedEventArgs e) => CheckActive.IsChecked = false;

        public void AddAplication()
        {
            dataGridApplication.ItemsSource = Order.Get();
        }
    }
}
