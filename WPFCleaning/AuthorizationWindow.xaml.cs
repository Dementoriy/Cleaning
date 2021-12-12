using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class AuthorizationWindow
    {
        public AuthorizationWindow()
        {
            new ApplicationContext(ApplicationContext.GetDb());
            InitializeComponent();
            //var role = new Position
            //{
            //    NamePosition = "Администратор",
            //    Description = "Обрабатывать заявки"
            //};
            //var employee = new Employee
            //{
            //    Position = role,
            //    Surname = "Ведерников",
            //    Name = "Дмитрий",
            //    MiddleName = "Михайлович",
            //    PassportData = "1111222223",
            //    EmployeeTelefonNumber = "79998887765",
            //    Employment_Date = DateTime.Now,
            //    Login = "Admin1",
            //    Password = "3a46fa46c1c732dc668a59cd9b7ff61a86426000ab2760d871e873c22c63093e"
            //};
            //Employee.Add(employee);
            //var role = new Position
            //{
            //    NamePosition = "Бригадир",
            //    Description = "Главный клинер"
            //};
            //var employee = new Employee
            //{
            //    Position = role,
            //    Surname = "Бессонов",
            //    Name = "Иван",
            //    MiddleName = "Анатольевич",
            //    PassportData = "1111222224",
            //    EmployeeTelefonNumber = "79998887764",
            //    Employment_Date = DateTime.Now,
            //    Login = "Brigadir1",
            //    Password = "60bcad77c43c4ab9840d8aa44b6c18e692e6c8e5e4f40351561c41274f1197c8"
            //};
            //Employee.Add(employee);
        }

        //private void SignInBrigadirButton_Click(object sender, RoutedEventArgs e)
        //{
        //    BrigadirWindow brigadirWindow = new BrigadirWindow();
        //    brigadirWindow.Show();
        //    this.Close();
        //}
        //private void SignInButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    this.Close();
        //}
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = Employee.GetEmployee(TextBoxLogin.Text.Trim(), GetHash(PasswordBox.Password.Trim()));

            if (employee != null)
            {
                if (employee.PositionID == 1)
                {
                    MainWindow mainWindow = new MainWindow(employee);
                    mainWindow.Show();
                    this.Close();
                }
                else if (employee.PositionID == 2)
                {
                    BrigadirWindow brigadirWindow = new BrigadirWindow(employee);
                    brigadirWindow.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Введен неверный логин или пароль.\n Повторите попытку.");
        }
        private static string GetHash(string input)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
