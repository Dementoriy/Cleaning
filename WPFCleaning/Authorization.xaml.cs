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

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }


        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TextBoxLogin.Text == "Admin" && PasswordBox.Password == "123")
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else MessageBox.Show("ТЫ ШПИОН!");
            }
            catch { }
        }
    }
}
