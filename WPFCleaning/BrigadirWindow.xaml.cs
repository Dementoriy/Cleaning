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

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для BrigadirWindow.xaml
    /// </summary>
    public partial class BrigadirWindow : Window
    {
        Page BrigadeApplications;
        //Page applications;
        public BrigadirWindow()
        {
            InitializeComponent();
            AddPage();
        }
        public void AddPage()
        {
            BrigadeApplications = new BrigadeApplications();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Выйти из учетной записи?",
                "Выход",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }
        private void ButtonClickBrigadeInfo(object sender, RoutedEventArgs e)
        {
            BtnBrigadeInfo.BorderBrush = Brushes.White;
            BtnBrigadeOrder.BorderBrush = Brushes.Black;
        }
        private void ButtonClickBrigadeOrder(object sender, RoutedEventArgs e)
        {
            BrigadeFrame.Navigate(BrigadeApplications);
            BtnBrigadeInfo.BorderBrush = Brushes.Black;
            BtnBrigadeOrder.BorderBrush = Brushes.White;
        }
    }
}
