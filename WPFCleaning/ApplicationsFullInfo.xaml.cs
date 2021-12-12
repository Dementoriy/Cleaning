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
using System.Linq;
using CleaningDLL;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsFullInfo.xaml
    /// </summary>
    public partial class ApplicationsFullInfo : Window
    {
        public ApplicationsFullInfo()
        {
            InitializeComponent();
        }
        public void AddSelectedOrder(int orderID)
        {
            //orderInfo.Text = Order.GetOrderInfo();
        }
    }
}
