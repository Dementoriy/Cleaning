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

        //List<int> listService = new List<int>() { 0, 0, 0, 0, 0, 0, 0};
        int[,] arrayService = new int[2, 7];
        public int GetIdServiceByCheckBox()
        {
            if ((bool)CheckExpressClean.IsChecked)
            {
                arrayService[0,0] = (Service.GetIdService(CheckExpressClean.Content.ToString()));
                arrayService[1,0] = Convert.ToInt32(TextBoxSquare.Text);
                return Service.GetIdService(CheckExpressClean.Content.ToString());
            }
                
            if ((bool)CheckGeneralClean.IsChecked)
            {
                arrayService[0, 0] = (Service.GetIdService(CheckGeneralClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(TextBoxSquare.Text);
                return Service.GetIdService(CheckGeneralClean.Content.ToString());
            }
                
            if ((bool)CheckBuildingClean.IsChecked)
            {
                arrayService[0, 0] = (Service.GetIdService(CheckBuildingClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(TextBoxSquare.Text);
                return Service.GetIdService(CheckBuildingClean.Content.ToString());
            }
            if ((bool)CheckOfficeClean.IsChecked)
            {
                arrayService[0, 0] = (Service.GetIdService(CheckOfficeClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(TextBoxSquare.Text);
                return Service.GetIdService(CheckOfficeClean.Content.ToString());
            }     
            return 0;
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
        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            GetIdServiceByCheckBox();
            {
                Client client;
                
                if(Client.ClientByTelefonIsNew(_clientPage.Telefon.Text))
                {
                    client = new Client
                    {
                        Surname = _clientPage.Surname.Text,
                        Name = _clientPage.Name.Text,
                        MiddleName = _clientPage.MiddleName.Text,
                        ClientTelefonNumber = _clientPage.Telefon.Text,
                        IsOldClient = false
                    };
                }
                else client = Client.GetClientByTelefon(_clientPage.Telefon.Text);
                
                var address = new Address
                {
                    Street = _clientPage.Street.Text,
                    HouseNumber = _clientPage.HouseNumber.Text,
                    Building = _clientPage.Building.Text,
                    Entrance = _clientPage.Entrance.Text,
                    Apartment_Number = _clientPage.Apartment_Number.Text
                };

                string NewDate = (DatePicker.Text + " " + SelectTime.Text);
                Order order;

                if (DateTime.Parse(NewDate) > DateTime.Now)
                {
                    order = new Order
                    {
                        Status = "Ожидает",
                        Client = client,
                        Employee = _emp,
                        Address = address,
                        Brigade = Brigade.GetBrigadeByID(Convert.ToInt32(BrigadeBox.Text)),
                        Date = DateTime.Parse(NewDate),
                        FinalPrice = Convert.ToInt32(PriceBox.Text),
                        ApproximateTime = at
                    };
                    Context.Db.Order.Add(order);
                    for (int i = 0; i < 7; i++)
                    {
                        if (arrayService[0, i] != 0)
                        {
                            var providedService = new ProvidedService
                            {
                                Order = order,
                                Service = Service.GetServiceByID(arrayService[0, i]),
                                Amount = arrayService[1, i],
                            };
                            Context.Db.ProvidedService.Add(providedService);
                        }
                    }
                    var contract = new Contract
                    {
                        Client = client,
                        Employee = _emp,
                        Date_Of_Contract = DateTime.Now
                    };

                    Context.Db.Address.Add(address);
                    Context.Db.Contract.Add(contract);
                    Context.Db.SaveChanges();
                    MessageBox.Show("Успешно!");
                    ClearNewApplication();
                    _clientPage.ClearClientInfo();
                }
                else MessageBox.Show("Некоректная дата");
            }
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

                    arrayService[0, 1] = idService;
                    arrayService[1, 1] = Convert.ToInt32(KolvoWindow.Text);
                    finalPrice += Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoWindow.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoDoor.Text != "")
                {
                    string str = "Мойка стеклянных дверей";
                    idService = Service.GetIdService(str);

                    arrayService[0, 2] = idService;
                    arrayService[1, 2] = Convert.ToInt32(KolvoDoor.Text);
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

                    arrayService[0, 3] = idService;
                    arrayService[1, 3] = Convert.ToInt32(KolvoSofa.Text);
                    finalPrice += Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoSofa.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoArmcheir.Text != "")
                {
                    string str = "Химчистка кресел";
                    idService = Service.GetIdService(str);

                    arrayService[0, 4] = idService;
                    arrayService[1, 4] = Convert.ToInt32(KolvoArmcheir.Text);
                    finalPrice += Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoArmcheir.Text) * Service.GetPrice(idService).Time;
                }
                if (KolvoCarpet.Text != "")
                {
                    string str = "Химчистка ковров";
                    idService = Service.GetIdService(str);

                    arrayService[0, 5] = idService;
                    arrayService[1, 5] = Convert.ToInt32(KolvoCarpet.Text);
                    finalPrice += Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Price;
                    approximateTime += Convert.ToInt32(KolvoCarpet.Text) * Service.GetPrice(idService).Time;
                }
            }
            if ((bool)Dezinfection.IsChecked)
            {
                string str = "Дезинфекция";
                idService = Service.GetIdService(str);

                arrayService[0, 6] = idService;
                arrayService[1, 6] = Convert.ToInt32(KolvoDezinfection.Text);
                finalPrice += Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Price;
                approximateTime += Convert.ToInt32(KolvoDezinfection.Text) * Service.GetPrice(idService).Time;
            }

            if ((bool)_clientPage.CheckOldClient.IsChecked)
            {
                finalPrice = Convert.ToInt32((finalPrice * 90)/100);
            }

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
        private void SelectTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tt = SelectTime.Text;

            if (tt.Length == 1)
            {
                if (Convert.ToInt32(tt) > 2)
                {
                    SelectTime.Text = "0" + tt;
                    SelectTime.SelectionStart = SelectTime.Text.Length;
                }
            }
            if (tt.Length == 2)
            {
                if (Convert.ToInt32(tt.Substring(0, 2)) > 23)
                {
                    SelectTime.Text = tt.Remove(1, 1);
                    SelectTime.SelectionStart = SelectTime.Text.Length;
                }
            }
            if (tt.Length == 4)
            {
                if (Convert.ToInt32(tt.Substring(3, 1)) > 5)
                {
                    SelectTime.Text = tt.Substring(0, 3) + "0" + tt.Substring(3, 1);
                    SelectTime.SelectionStart = SelectTime.Text.Length;
                }
            }
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
    }
}
