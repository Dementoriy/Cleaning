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
            //if (KolvoWindow.Text != "0")
            //finalPrice -= Convert.ToInt32(KolvoWindow.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //finalPrice -= Convert.ToInt32(KolvoDoor.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //PriceBox.Text = finalPrice.ToString();
            //approximateTime -= Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Time;
            //approximateTime -= Convert.ToInt32(KolvoDoor.Text) * Service.GetPrice(idService).Time;
            //ApproximateTime.Text = approximateTime.ToString();
            //if (finalPrice != 0)
            //{
            KolvoWindow.Text = "0";
            KolvoDoor.Text = "0";
            //}
        }
        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = ChemistryClean.IsEnabled;
        }
        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = false;
            //finalPrice -= Convert.ToInt32(KolvoSofa.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //finalPrice -= Convert.ToInt32(KolvoArmcheir.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //finalPrice -= Convert.ToInt32(KolvoCarpet.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //approximateTime -= Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Time;
            //approximateTime -= Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Time;
            //approximateTime -= Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Time;
            //if (finalPrice != 0)
            //{
                KolvoSofa.Text = "0";
                KolvoArmcheir.Text = "0";
                KolvoCarpet.Text = "0";
            //}
        }
        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = Dezinfection.IsEnabled;
        }
        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = false;
            //finalPrice -= Convert.ToInt32(KolvoDezinfection.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            //approximateTime -= Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Time;
            //if (finalPrice != 0)
                KolvoDezinfection.Text = "0";
        }

        private void CheckExpressClean_Checked(object sender, RoutedEventArgs e)
        {
            CheckGeneralClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
            idService = Service.GetIdService(CheckExpressClean.Content.ToString());
        }
        private void CheckGeneralClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
            idService = Service.GetIdService(CheckGeneralClean.Content.ToString());
        }
        private void CheckBuildingClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckGeneralClean.IsChecked = false;
            CheckOfficeClean.IsChecked = false;
            idService = Service.GetIdService(CheckBuildingClean.Content.ToString());
        }
        private void CheckOfficeClean_Checked(object sender, RoutedEventArgs e)
        {

            CheckExpressClean.IsChecked = false;
            CheckGeneralClean.IsChecked = false;
            CheckBuildingClean.IsChecked = false;
            idService = Service.GetIdService(CheckOfficeClean.Content.ToString());
        }
        private void CheckService_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (finalPrice != 0)
            {
                finalPrice -= Service.GetPrice(Service.GetIdService(checkBox.Content.ToString())).Price * Convert.ToInt32(TextBoxSquare.Text);
                approximateTime -= Service.GetPrice(Service.GetIdService(CheckExpressClean.Content.ToString())).Time * Convert.ToInt32(TextBoxSquare.Text);
            }
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
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            ButtonCalculate.BtnCalculate(this, _clientPage);
        }
        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            arrayService = ButtonCalculate.arrayService;
            ButtonAddOrder.BtnAddOrder(this, _clientPage, _emp);
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
        private void TextBoxSquare_GotFocus(object sender, RoutedEventArgs e)
        {
            //if (TextBoxSquare.Text == "")
            //{
            //    TextBoxSquare.Text = " m^2";
            //    TextBoxSquare.SelectionStart = 0;
            //}
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
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }

        private void CorrectSquare_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsInitialized)
                CorrectValue.CorrectSqare(this);
        }
    }
}
