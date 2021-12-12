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

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для NewApplication.xaml
    /// </summary>
    public partial class NewApplication : Page
    {
        public NewApplication()
        {
            InitializeComponent();
            ChemistryCleanBox.IsEnabled = false;
            WindowCleanBox.IsEnabled = false;
            DezinfectionBox.IsEnabled = false;
        }

        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = ChemistryClean.IsEnabled;
        }
        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = false;
        }
        private void WindowClean_Checked(object sender, RoutedEventArgs e)
        {
            WindowCleanBox.IsEnabled = WindowClean.IsEnabled;
        }
        private void WindowClean_Unchecked(object sender, RoutedEventArgs e)
        {
            WindowCleanBox.IsEnabled = false;
        }
        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = Dezinfection.IsEnabled;
        }
        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = false;
        }
        private void CheckExpressClean_Checked(object sender, RoutedEventArgs e)
        {
            CheckGeneralClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
        }
        private void CheckGeneralClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
        }
        private void CheckBuildingClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckGeneralClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
        }
        private void CheckOfficeClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckGeneralClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
        }
        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Convert.ToInt32(TextBoxSquare.Text);
                if(CheckExpressClean.IsChecked == true) { MessageBox.Show("OK"); }
                else if(CheckGeneralClean.IsChecked == true) { MessageBox.Show("OK"); }
                else if (CheckBuildingClean.IsChecked == true) { MessageBox.Show("OK"); }
                else if (CheckOfficeClean.IsChecked == true) { MessageBox.Show("OK"); };
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите число в поле \"Площадь\"");
            }
            catch when(CheckExpressClean.IsChecked == false && CheckGeneralClean.IsChecked == false && CheckBuildingClean.IsChecked == false && CheckOfficeClean.IsChecked == false)
            {
                MessageBox.Show("Ни одна из услуг не выбрана");
            }
        }
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BtnBrigadeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (BrigadeBox.SelectedIndex != -1)
            {
                BrigadeInfoWindow brigadeInfoWindow = new BrigadeInfoWindow(Convert.ToInt32(((TextBlock)BrigadeBox.SelectedItem).Text));
                brigadeInfoWindow.Show();
            }
            else MessageBox.Show("Выберите бригаду");
        }

        private void BrigadeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
