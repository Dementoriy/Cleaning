﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для BrigadeInfoPage.xaml
    /// </summary>
    public partial class BrigadeInfoPage : Page
    {
        private Employee _br;
        public BrigadeInfoPage(Employee br)
        {
            _br = br;
            InitializeComponent();
            SelectedEmployeeInfo();
        }
        private void SelectedEmployeeInfo()
        {
            List<Employee.EmployeeFullInfo> listSort = Employee.GetEmployeeFullInfo();
            if (SearchBox.Text != "")
            {
                listSort = listSort.Where(e => e.Cleaner.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Positions.ToLower().Contains(SearchBox.Text.ToLower())
                || e.WorkExperience.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Telefone.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                ).ToList();
            }
            dataGridApplication.ItemsSource = listSort.Where(d => d.Brigade == _br.BrigadeID);
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectedEmployeeInfo();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedEmployeeInfo();
        }
    }
}
