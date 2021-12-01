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
        public MainWindow()
        {
            InitializeComponent();
            AddPage();
        }
        public void AddPage()
        {
            client = new Client();
            newApplication = new NewApplication();
            applications = new Applications();
        }
        private void ButtonClickClient(object sender, RoutedEventArgs e)
        {
            this.View.NavigationService.Navigate(client);
        }

        private void ButtonClickNewApplication(object sender, RoutedEventArgs e)
        {
            this.View.NavigationService.Navigate(newApplication);
        }

        private void ButtonClickApplication(object sender, RoutedEventArgs e)
        {
            this.View.NavigationService.Navigate(applications);
        }
    }
}
