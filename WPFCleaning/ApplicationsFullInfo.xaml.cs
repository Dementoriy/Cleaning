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
using System.Windows.Shapes;
using System.Linq;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsFullInfo.xaml
    /// </summary>
    public partial class ApplicationsFullInfo : Window
    {
        public ApplicationsFullInfo()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }
        public void AddSelectedOrder(int orderID)
        {
            //orderInfo.Text = Order.GetOrderInfo();
        }

        private void CheckExpressClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckGeneralClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBuildingClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckOfficeClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void WindowClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void KolvoService_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void KolvoService_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CheckService_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void WindowClean_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxSquare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBoxSquare_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBoxSquare_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrigadeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
