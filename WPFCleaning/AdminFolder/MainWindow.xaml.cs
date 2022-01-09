using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CleaningDLL.Entity;


namespace WPFCleaning.Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ReportPage reportPage { get; }
        public ClientPage clientPage { get; }
        public NewApplication newApplication { get; }
        public Applications applications;
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
            reportPage.SelectedOrderInfo();
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
        private void ButtonClickNewApplication(object sender, RoutedEventArgs e)
        {
            View.Navigate(newApplication);
            ReportBtn.BorderBrush = Brushes.Black;
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.White;
            OrderBtn.BorderBrush = Brushes.Black;
        }

        private void ButtonClickApplication(object sender, RoutedEventArgs e)
        {
            View.Navigate(applications);
            applications.SelectedOrderInfo();
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
