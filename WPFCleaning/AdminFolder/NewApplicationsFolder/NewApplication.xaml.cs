using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    /// <summary>
    /// Логика взаимодействия для NewApplication.xaml
    /// </summary>
    public partial class NewApplication : Page 
    {
        private ClientPage _clientPage;
        private Employee _emp;

        public NewApplication(Page clientPage, Employee emp)
        {
            _clientPage = (ClientPage)clientPage;
            _emp = emp;
            InitializeComponent();
            ChemistryCleanBox.IsEnabled = false;
            WindowCleanBox.IsEnabled = false;
            DezinfectionBox.IsEnabled = false;
            PriceBox.Text = "0 ₽";
            ApproximateTime.Text = "0ч. 0мин.";
        }

        public int idService;
        public decimal finalPrice = 0;
        public int approximateTime = 0;
        
    private void WindowClean_Checked(object sender, RoutedEventArgs e)
        {
            WindowCleanBox.IsEnabled = WindowClean.IsEnabled;
        }
        private void WindowClean_Unchecked(object sender, RoutedEventArgs e)
        {

            WindowCleanBox.IsEnabled = false;
            OrderPrice.Calculate(this, _clientPage);
            KolvoWindow.Text = "0";
            KolvoDoor.Text = "0";

        }
        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = ChemistryClean.IsEnabled;
        }
        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = false;
            OrderPrice.Calculate(this, _clientPage);
            KolvoSofa.Text = "0";
            KolvoArmcheir.Text = "0";
            KolvoCarpet.Text = "0";
        }
        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = Dezinfection.IsEnabled;
        }
        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = false;
            OrderPrice.Calculate(this, _clientPage);
            KolvoDezinfection.Text = "0";
        }

        private void CheckExpressClean_Checked(object sender, RoutedEventArgs e)
        {
            if (TextBoxSquare.Text != "")
            {
                CheckGeneralClean.IsChecked = false;
                CheckBuildingClean.IsChecked = false;
                CheckOfficeClean.IsChecked = false;
                idService = Service.GetIdService(CheckExpressClean.Content.ToString());
                OrderPrice.Calculate(this, _clientPage);
            }
            else
            {
                CheckExpressClean.IsChecked = false;
                MessageBox.Show("Введите площадь!");
            } 
        }
        private void CheckGeneralClean_Checked(object sender, RoutedEventArgs e)
        {
            if (TextBoxSquare.Text != "")
            {
                CheckExpressClean.IsChecked = false;
                CheckBuildingClean.IsChecked = false;
                CheckOfficeClean.IsChecked = false;
                idService = Service.GetIdService(CheckGeneralClean.Content.ToString());
                OrderPrice.Calculate(this, _clientPage);
            }
            else
            {
                CheckGeneralClean.IsChecked = false;
                MessageBox.Show("Введите площадь!");
            }
        }
        private void CheckBuildingClean_Checked(object sender, RoutedEventArgs e)
        {
            if (TextBoxSquare.Text != "")
            {
                CheckExpressClean.IsChecked = false;
                CheckGeneralClean.IsChecked = false;
                CheckOfficeClean.IsChecked = false;
                idService = Service.GetIdService(CheckBuildingClean.Content.ToString());
                OrderPrice.Calculate(this, _clientPage);
            }
            else
            {
                CheckBuildingClean.IsChecked = false;
                MessageBox.Show("Введите площадь!");
            }
        }
        private void CheckOfficeClean_Checked(object sender, RoutedEventArgs e)
        {
            if (TextBoxSquare.Text != "")
            {
                CheckExpressClean.IsChecked = false;
                CheckGeneralClean.IsChecked = false;
                CheckBuildingClean.IsChecked = false;
                idService = Service.GetIdService(CheckOfficeClean.Content.ToString());
                OrderPrice.Calculate(this, _clientPage);
            }
            else
            {
                CheckOfficeClean.IsChecked = false;
                MessageBox.Show("Введите площадь!");
            }
        }
        private void CheckService_Unchecked(object sender, RoutedEventArgs e)
        {
            OrderPrice.Calculate(this, _clientPage);
            //TextBoxSquare.Text = "";
        }

        public void ClearNewApplication()
        {
            CheckExpressClean.IsChecked = false;
            CheckGeneralClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
            WindowClean.IsChecked = false;
            ChemistryClean.IsChecked = false;
            Dezinfection.IsChecked = false;
            TextBoxSquare.Text = "";
            DatePicker.Text = "";
            SelectTime.Text = "";
            BrigadeBox.Text = "";
            PriceBox.Text = "";
            ApproximateTime.Text = "";
            Comment.Text = "";
        }
        public bool IsCorrectData()
        {
            return CorrectValue.CorrectDate(_clientPage, this);
        }

        public int[,] arrayService = new int[2, 7];

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderPrice.Calculate(this, _clientPage);
            arrayService = OrderPrice.arrayService;
            NewOrder.AddOrder(this, _clientPage, _emp);
        }

        public int at = 0;
  
        private void BtnBrigadeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (BrigadeBox.SelectedIndex != -1)
            {
                BrigadeInfoWindow brigadeInfoWindow = new BrigadeInfoWindow(Employee.GetEmployeeBrigade(int.Parse(BrigadeBox.Text)));
                brigadeInfoWindow.Show();
            }
            else MessageBox.Show("Выберите бригаду");
        }

        private void KolvoService_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "0")
            {
                textBox.Text = "";
            }
        }

        private void KolvoService_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
            OrderPrice.Calculate(this, _clientPage);
        }
        private void SelectTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CorrectTime.PreviewTextInput(this, e);
        }
        private void SelectTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            CorrectTime.TextChanged(this);
        }
        private void SelectTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }
        public void CheckToInt(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }
        private void CheckKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; 
            }
        }

        private void CorrectSquare_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsInitialized)
                CorrectValue.CorrectSqare(this);
        }
    }
}
