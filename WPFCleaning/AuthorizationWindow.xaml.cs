﻿using System;
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
            InitializeComponent();
            var role = new Position
            {
                NamePosition = "Администратор",
                Description = "Обрабатывать заявки"
            };
            var employee = new Employee
            {
                Position = role,
                Surname = "Ведерников",
                Name = "Дмитрий",
                MiddleName = "Михайлович",
                PassportData = "1111222222",
                EmployeeTelefonNumber = "79998887766",
            };
        }

        private void SignInBrigadirButton_Click(object sender, RoutedEventArgs e)
        {
            BrigadirWindow brigadirWindow = new BrigadirWindow();
            brigadirWindow.Show();
            this.Close();
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //private void SignInButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Employee employee = Employee.GetEmployee(TextBoxLogin.Text, GetHash(PasswordBox.Password));

        //    if (employee != null)
        //    {
        //        if (employee.Position.ID == 1)
        //        {
        //            MainWindow mainWindow = new MainWindow();
        //            mainWindow.Show();
        //            this.Close();
        //        }
        //        else if (employee.Position.ID == 2)
        //        {
        //            BrigadirWindow brigadirWindow = new BrigadirWindow();
        //            brigadirWindow.Show();
        //            this.Close();
        //        }
        //    }
        //    else MessageBox.Show("Введен неверный логин или пароль.\n Повторите попытку.");
        //}
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
