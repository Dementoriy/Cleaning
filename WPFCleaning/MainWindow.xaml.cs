﻿using System;
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
        Page clientPage;
        Page newApplication;
        Page applications;
        public MainWindow()
        {
            InitializeComponent();
            AddPage();
            View.Navigate(clientPage);
            WindowState = WindowState.Maximized;
        }
        public void AddPage()
        {
            clientPage = new ClientPage();
            newApplication = new NewApplication();
            applications = new Applications();
        }
        public void EmployeeEnter()
        {
            //using (var db = new ApplicationContext())
            //TextBlockEmployeeEnter.Text = Employee.AddFIO(ID);
        }
        private void ButtonClickClient(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(client);

            View.Navigate(clientPage);
            ClientBtn.BorderBrush = Brushes.White;
            //ClientBtn.Foreground = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.Black;
            //NewOrderBtn.Foreground = Brushes.White;
            OrderBtn.BorderBrush = Brushes.Black;
            //OrderBtn.Foreground = Brushes.White;
        }

        private void ButtonClickNewApplication(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(newApplication);

            View.Navigate(newApplication);
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.White;
            OrderBtn.BorderBrush = Brushes.Black;
        }

        private void ButtonClickApplication(object sender, RoutedEventArgs e)
        {
            //this.View.NavigationService.Navigate(applications);

            View.Navigate(applications);
            ClientBtn.BorderBrush = Brushes.Black;
            NewOrderBtn.BorderBrush = Brushes.Black;
            OrderBtn.BorderBrush = Brushes.White;
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //private void Exit_Click(object sender, RoutedEventArgs e)
        //{
        //    //MessageBox.Show("Выйти из учетной записи?", MessageBoxButtons.YesNo);
        //    if (MessageBox.Show("Выйти из учетной записи?") == DialogResult.OK)
        //    {
        //        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        //        authorizationWindow.Show();
        //        this.Close();
        //    }
        //}
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
