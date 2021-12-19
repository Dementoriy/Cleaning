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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using CleaningDLL;

namespace WPFCleaning
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

        private int idService;
        decimal finalPrice = 0;
        int approximateTime = 0;
        private void ChemistryClean_Checked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = ChemistryClean.IsEnabled;
        }
        private void ChemistryClean_Unchecked(object sender, RoutedEventArgs e)
        {
            ChemistryCleanBox.IsEnabled = false;
            finalPrice -= Convert.ToInt32(KolvoSofa.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            finalPrice -= Convert.ToInt32(KolvoArmcheir.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            finalPrice -= Convert.ToInt32(KolvoCarpet.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            approximateTime -= Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Time;
            approximateTime -= Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Time;
            approximateTime -= Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Time;
            if (finalPrice != 0)
            {

                KolvoSofa.Text = "0";
                KolvoArmcheir.Text = "0";
                KolvoCarpet.Text = "0";
            }
        }
        private void WindowClean_Checked(object sender, RoutedEventArgs e)
        {
            WindowCleanBox.IsEnabled = WindowClean.IsEnabled;
        }
        private void WindowClean_Unchecked(object sender, RoutedEventArgs e)
        {
            WindowCleanBox.IsEnabled = false;
            finalPrice -= Convert.ToInt32(KolvoWindow.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            finalPrice -= Convert.ToInt32(KolvoDoor.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
            approximateTime -= Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Time;
            approximateTime -= Convert.ToInt32(KolvoDoor.Text) * Service.GetPrice(idService).Time;
            if (finalPrice != 0)
            {
                KolvoWindow.Text = "0";
                KolvoDoor.Text = "0";
            }
        }
        private void Dezinfection_Checked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = Dezinfection.IsEnabled;
        }
        private void Dezinfection_Unchecked(object sender, RoutedEventArgs e)
        {
            DezinfectionBox.IsEnabled = false;
            if (finalPrice != 0)
                finalPrice -= Convert.ToInt32(KolvoDezinfection.Text) * Convert.ToInt32(Service.GetPrice(idService).Price);
                approximateTime -= Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Time;
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

        public int GetIdServiceByCheckBox()
        {
            if ((bool)CheckExpressClean.IsChecked)
                return Service.GetIdService(CheckExpressClean.Content.ToString());
            if ((bool)CheckGeneralClean.IsChecked)
                return Service.GetIdService(CheckGeneralClean.Content.ToString());
            if ((bool)CheckBuildingClean.IsChecked)
                return Service.GetIdService(CheckBuildingClean.Content.ToString());
            if ((bool)CheckOfficeClean.IsChecked)
                return Service.GetIdService(CheckOfficeClean.Content.ToString());
            return 0;
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client
            {
                Surname = _clientPage.Surname.Text,
                Name = _clientPage.Name.Text,
                MiddleName = _clientPage.MiddleName.Text,
                ClientTelefonNumber = _clientPage.Telefon.Text
            };
            var address = new Address
            {
                Street = _clientPage.Street.Text,
                HouseNumber = _clientPage.HouseNumber.Text,
                Building = _clientPage.Building.Text,
                Entrance = _clientPage.Entrance.Text,
                Apartment_Number = _clientPage.Apartment_Number.Text
            };

            var order = new Order
            {
                Status = "Ожидает",
                Client = client,
                Employee = _emp,
                Address = address,
                Brigade = Brigade.GetBrigadeByID(Convert.ToInt32(BrigadeBox.Text)),
                Date = DateTime.Now,
                FinalPrice = Convert.ToInt32(PriceBox.Text),
                ApproximateTime = at
            };
            var providedService = new ProvidedService
            {
                Order = order,
                Service = Service.GetServiceByID(GetIdServiceByCheckBox()),
                Amount = Convert.ToInt32(TextBoxSquare.Text),
                
            };
            var contract = new Contract
            {
                Client = client,
                Employee = _emp,
                Date_Of_Contract = DateTime.Now
            };
            Context.Db.Contract.Add(contract);
            Context.Db.ProvidedService.Add(providedService);
            Context.Db.SaveChanges();
        }

        int at = 0;

        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            PriceBox.Text = "";
            ApproximateTime.Text = "";
            finalPrice = 0;
            approximateTime = 0;
            try
            {
                if ((bool)CheckExpressClean.IsChecked)
                {
                    finalPrice += Service.GetPrice(Service.GetIdService(CheckExpressClean.Content.ToString())).Price * Convert.ToInt32(TextBoxSquare.Text);
                    approximateTime += Service.GetPrice(Service.GetIdService(CheckExpressClean.Content.ToString())).Time * Convert.ToInt32(TextBoxSquare.Text);
                }
                if ((bool)CheckGeneralClean.IsChecked)
                {
                    finalPrice += Service.GetPrice(Service.GetIdService(CheckGeneralClean.Content.ToString())).Price * Convert.ToInt32(TextBoxSquare.Text);
                    approximateTime += Service.GetPrice(Service.GetIdService(CheckGeneralClean.Content.ToString())).Time * Convert.ToInt32(TextBoxSquare.Text);
                }
                if ((bool)CheckBuildingClean.IsChecked)
                {
                    finalPrice += Service.GetPrice(Service.GetIdService(CheckBuildingClean.Content.ToString())).Price * Convert.ToInt32(TextBoxSquare.Text);
                    approximateTime += Service.GetPrice(Service.GetIdService(CheckBuildingClean.Content.ToString())).Time * Convert.ToInt32(TextBoxSquare.Text);
                }
                if ((bool)CheckOfficeClean.IsChecked)
                {
                    finalPrice += Service.GetPrice(Service.GetIdService(CheckOfficeClean.Content.ToString())).Price * Convert.ToInt32(TextBoxSquare.Text);
                    approximateTime += Service.GetPrice(Service.GetIdService(CheckOfficeClean.Content.ToString())).Time * Convert.ToInt32(TextBoxSquare.Text);
                }
            }
            catch
            {
                MessageBox.Show("Укажите площадь!");
            }

            if ((bool)WindowClean.IsChecked)
            {
                if (KolvoWindow.Text != "")
                {
                    string str = "Мойка окон";
                    idService = Service.GetIdService(str);

                    finalPrice += Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoDoor.Text != "")
                {
                    string str = "Мойка стеклянных дверей";
                    idService = Service.GetIdService(str);

                    finalPrice += Convert.ToInt32(KolvoDoor.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoDoor.Text) * Service.GetPrice(idService).Time;
                }
            }

            if ((bool)ChemistryClean.IsChecked)
            {
                if (KolvoSofa.Text != "")
                {
                    string str = "Химчистка диванов";
                    idService = Service.GetIdService(str);

                    finalPrice += Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoArmcheir.Text != "")
                {
                    string str = "Химчистка кресел";
                    idService = Service.GetIdService(str);

                    finalPrice += Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoCarpet.Text != "")
                {
                    string str = "Химчистка ковров";
                    idService = Service.GetIdService(str);

                    finalPrice += Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Time;
                }
            }
            if ((bool)Dezinfection.IsChecked)
            {
                string str = "Дезинфекция";
                idService = Service.GetIdService(str);

                finalPrice += Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Price;
                approximateTime += Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Time;
            }

            //if (ClientPage.CheckOldClient.IsChecked)
            //{
            //    finalPrice = finalPrice - 10 %;
            //}

            at = approximateTime;

            PriceBox.Text = finalPrice.ToString() ;
            ApproximateTime.Text = Order.GetTimeByInt(approximateTime);
            //ApproximateTime.Text = approximateTime.ToString();
        }
        
        private void BtnBrigadeInfo_Click(object sender, RoutedEventArgs e)
        {
            if (BrigadeBox.SelectedIndex != -1)
            {
                BrigadeInfoWindow brigadeInfoWindow = new BrigadeInfoWindow(Employee.GetEmployeeBrigade(int.Parse(BrigadeBox.Text)));
                brigadeInfoWindow.Show();
            }
            else MessageBox.Show("Выберите бригаду");
        }

        private void BrigadeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            string tt = SelectTime.Text;
            int val;

            if (tt.Length == 2)
            {
                SelectTime.Text = tt + ":";
                SelectTime.SelectionStart = SelectTime.Text.Length; //коретка в конец строки
            }
            if (tt.Length >= 5)
            {
                e.Handled = true; // отклоняем ввод
            }
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        private void SelectTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true; // если пробел, отклоняем ввод
            }
        }


        private void TextBoxSquare_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val))
            {
                e.Handled = true; // отклоняем ввод
            }
        }
        private void TextBoxSquare_PreviewKeyDown(object sender, KeyEventArgs e)
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
    }
}
