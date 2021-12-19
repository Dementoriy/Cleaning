using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CleaningDLL;



namespace WPFCleaning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Page reportPage { get; }
        public Page clientPage { get; }
        public Page newApplication { get; }
        public Page applications;
        public Employee emp { get; }
        public MainWindow(Employee e)
        {
            emp = e;
            InitializeComponent();

            reportPage = new ReportPage();
            clientPage = new ClientPage(this);
            newApplication = new NewApplication(clientPage, emp);
            applications = new Applications();

            View.Navigate(clientPage);
            WindowState = WindowState.Maximized;
            AddAdmin();
        }
        public void AddAdmin()
        {
            TextBlockEmployeeEnter.Text = emp.AddFIO();
        }
        private void ButtonClickReport(object sender, RoutedEventArgs e)
        {
            View.Navigate(reportPage);
            ReportBtn.BorderBrush = Brushes.White;
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.Black;
            OrderBtn.BorderBrush = Brushes.Black;
        }
        private void ButtonClickClient(object sender, RoutedEventArgs e)
        {
            View.Navigate(clientPage);
            ReportBtn.BorderBrush = Brushes.Black;
            ClientBtn.BorderBrush = Brushes.White;
            NewOrderBtn.BorderBrush = Brushes.Black;
            OrderBtn.BorderBrush = Brushes.Black;
        }
        public void GoNewApplication()
        {
            View.Navigate(newApplication);
            ReportBtn.BorderBrush = Brushes.Black;
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.White;
            OrderBtn.BorderBrush = Brushes.Black;
        }
        private void ButtonClickNewApplication(object sender, RoutedEventArgs e)
        {
            GoNewApplication();
        }

        private void ButtonClickApplication(object sender, RoutedEventArgs e)
        {
            View.Navigate(applications);
            ReportBtn.BorderBrush = Brushes.Black;
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.Black;
            OrderBtn.BorderBrush = Brushes.White;
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
    }
}
