using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    public partial class CorrectValue
    {
        private ClientPage _clientPage;

        public static void CorrectSqare(NewApplication newApplication)
        {
            int x = 0;
            if (newApplication.CheckExpressClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 240)
            {
                MessageBox.Show("Площадь больше 240!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckGeneralClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 96)
            {
                MessageBox.Show("Площадь больше 96!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckBuildingClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 72)
            {
                MessageBox.Show("Площадь больше 72!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckOfficeClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 135)
            {
                MessageBox.Show("Площадь больше 135!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.WindowClean.IsChecked.GetValueOrDefault() && newApplication.KolvoWindow.Text != "0" 
                && int.TryParse(newApplication.KolvoWindow.Text, out x))
            {
                if (x > 100)
                {
                    MessageBox.Show("Окон больше 100!");
                    newApplication.KolvoWindow.Text = "0";
                }
            }
            if (newApplication.WindowClean.IsChecked.GetValueOrDefault() && newApplication.KolvoDoor.Text != "0" 
                && int.TryParse(newApplication.KolvoDoor.Text, out x))
            {
                if (x > 50)
                {
                    MessageBox.Show("Дверей больше 50!");
                    newApplication.KolvoDoor.Text = "0";
                }
            }

            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault() && newApplication.KolvoSofa.Text != "0" 
                && int.TryParse(newApplication.KolvoSofa.Text, out x))
            {
                if (x > 6)
                {
                    MessageBox.Show("Диванов больше 6!");
                    newApplication.KolvoSofa.Text = "0";
                }  
            }
            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault() && newApplication.KolvoArmcheir.Text != "0" 
                && int.TryParse(newApplication.KolvoArmcheir.Text, out x))
            {
                if( x > 6)
                {
                    MessageBox.Show("Кресел больше 6!");
                    newApplication.KolvoArmcheir.Text = "0";
                }
            }
            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault() && newApplication.KolvoCarpet.Text != "0" 
                && int.TryParse(newApplication.KolvoCarpet.Text, out x))
            {
                if(x > 10)
                {
                    MessageBox.Show("Площадь ковра больше 10!");
                    newApplication.KolvoCarpet.Text = "0";
                }
            }
            if (newApplication.Dezinfection.IsChecked.GetValueOrDefault() && newApplication.KolvoDezinfection.Text != "0" 
                && int.TryParse(newApplication.KolvoDezinfection.Text, out x))
            {
                if(x > 370)
                {
                    MessageBox.Show("Площадь дезинфекции больше 370!");
                    newApplication.KolvoDezinfection.Text = "0";
                }
            }
        }
        public static bool CorrectDate(ClientPage clientPage, NewApplication newApplication)
        {
            if (clientPage.Telefon.Text == "")
            {
                MessageBox.Show("Заполните клиента!");
                return false;
            }
            else if (clientPage.Street.Text == "")
            {
                MessageBox.Show("Введите улицу!");
                return false;
            }
            else if (clientPage.HouseNumber.Text == "")
            {
                MessageBox.Show("Введите номер дома!");
                return false;
            }
            else if (newApplication.DatePicker.Text == "")
            {
                MessageBox.Show("Введите дату!");
                return false;
            }
            else if (newApplication.SelectTime.Text == "")
            {
                MessageBox.Show("Введите время!");
                return false;
            }
            else if (newApplication.BrigadeBox.Text == "")
            {
                MessageBox.Show("Введите бригаду!");
                return false;
            }
            else if (newApplication.PriceBox.Text == "")
            {
                MessageBox.Show("Нажмите кнопку рассчитать!");
                return false;
            }
            else if (Convert.ToInt32(newApplication.PriceBox.Text) == 0)
            {
                MessageBox.Show("Ни одна из услуг не выбрана");
                newApplication.PriceBox.Text = "";
                newApplication.ApproximateTime.Text = "";
                return false;
            }
            else return true;
        }
    }
}
