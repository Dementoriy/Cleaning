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


namespace WPFCleaning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Page client;
        Page newApplication;
        Page applications;
        Page enter;
        public MainWindow()
        {
            InitializeComponent();
            AddPage();
            View.Navigate(client);
        }
        public void AddPage()
        {
            client = new Client();
            newApplication = new NewApplication();
            applications = new Applications();
        }
        private void ButtonClickClient(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(client);

            View.Navigate(client);
            ClientBtn.BorderBrush = Brushes.White;
            //ClientBtn.Foreground = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.DarkBlue;
            //NewOrderBtn.Foreground = Brushes.White;
            OrderBtn.BorderBrush = Brushes.DarkBlue;
            //OrderBtn.Foreground = Brushes.White;
        }

        private void ButtonClickNewApplication(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(newApplication);

            View.Navigate(newApplication);
            ClientBtn.BorderBrush = Brushes.DarkBlue;
            NewOrderBtn.BorderBrush = Brushes.White;
            OrderBtn.BorderBrush = Brushes.DarkBlue;
        }

        private void ButtonClickApplication(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(applications);

            View.Navigate(applications);
            ClientBtn.BorderBrush = Brushes.DarkBlue;
            NewOrderBtn.BorderBrush = Brushes.DarkBlue;
            OrderBtn.BorderBrush = Brushes.White;
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
