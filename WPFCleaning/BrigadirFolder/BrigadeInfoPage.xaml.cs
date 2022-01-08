using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using CleaningDLL.Entity;

namespace WPFCleaning.Brigadir
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
            dataGridApplication.ItemsSource = listSort.Where(d => d.Brigade == _br.BrigadeID).OrderBy(o => o.Positions);
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
