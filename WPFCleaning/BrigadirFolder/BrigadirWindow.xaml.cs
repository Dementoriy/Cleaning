using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CleaningDLL.Entity;

namespace WPFCleaning.Brigadir
{
    /// <summary>
    /// Логика взаимодействия для BrigadirWindow.xaml
    /// </summary>
    public partial class BrigadirWindow : Window
    {
        Page brigadeApplications;
        Page brigadeInfoPage;

        private Employee emp;
        public BrigadirWindow(Employee e)
        {
            emp = e;
            InitializeComponent();
            AddPage();
            BrigadeFrame.Navigate(brigadeInfoPage);
            WindowState = WindowState.Maximized;
            
            AddBrig();

        }
        public void AddBrig()
        {
            TextBlockEmployeeEnter.Text = emp.AddFIO();
        }

        public void AddPage()
        {
            brigadeApplications = new BrigadeApplications(emp);
            brigadeInfoPage = new BrigadeInfoPage(emp);
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
            BrigadeFrame.Navigate(brigadeInfoPage);
            BtnBrigadeInfo.BorderBrush = Brushes.White;
            BtnBrigadeOrder.BorderBrush = Brushes.Black;
        }
        private void ButtonClickBrigadeOrder(object sender, RoutedEventArgs e)
        {
            BrigadeFrame.Navigate(brigadeApplications);
            BtnBrigadeInfo.BorderBrush = Brushes.Black;
            BtnBrigadeOrder.BorderBrush = Brushes.White;
        }
    }
}
