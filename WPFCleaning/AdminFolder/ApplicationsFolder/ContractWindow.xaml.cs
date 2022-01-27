using System.Windows;
using CleaningDLL.Entity;
using System.Collections.Generic;
using System;

namespace WPFCleaning.AdminFolder.ApplicationsFolder
{
    /// <summary>
    /// Логика взаимодействия для ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public ContractWindow(Order order)
        {
            InitializeComponent();
            GetContractInfo(order);
        }

        private void GetContractInfo(Order order)
        {
            Client client = order.Client;
            Employee admin = order.Employee;
            Employee brigadir = Employee.GetBrigadirByBrigada(order.BrigadeID);
            decimal finalPrice = order.FinalPrice;
            DateTime dateTime = Contract.GetContractById(order.ContractID).DateOfContract;
            int orderNumber = order.ID;

            List<Human> people = new List<Human>();
            people.Add(client);
            people.Add(admin);
            people.Add(brigadir);

            string result = "";
            foreach(var human in people)
            {
                result += ("\n\n" + human.GetFullName());
            }

            result += "\n\n\nНомер заявки: " + orderNumber;
            result += "\n\nСтоимость оказываемых услуг: " + finalPrice;
            result += "\n\nДата оформления: " + dateTime;

            ContracrTextBox.Text = result;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
