using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WPFCleaning.Admin
{
    public partial class CorrectValue
    {
        private ClientPage _clientPage;

        public static void CorrectSqare(NewApplication newApplication)
        {
            int x = 0;
            if (newApplication.CheckExpressClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 200)
            {
                MessageBox.Show("Площадь больше 200!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckGeneralClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 100)
            {
                MessageBox.Show("Площадь больше 100!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckBuildingClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 100)
            {
                MessageBox.Show("Площадь больше 100!");
                newApplication.TextBoxSquare.Text = "";
            }
            if (newApplication.CheckOfficeClean.IsChecked.GetValueOrDefault() && newApplication.TextBoxSquare.Text != "" 
                && Convert.ToInt32(newApplication.TextBoxSquare.Text) > 200)
            {
                MessageBox.Show("Площадь больше 200!");
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
                if (x > 30)
                {
                    MessageBox.Show("Диванов(мест) больше 30!");
                    newApplication.KolvoSofa.Text = "0";
                }  
            }
            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault() && newApplication.KolvoArmcheir.Text != "0" 
                && int.TryParse(newApplication.KolvoArmcheir.Text, out x))
            {
                if( x > 30)
                {
                    MessageBox.Show("Кресел больше 30!");
                    newApplication.KolvoArmcheir.Text = "0";
                }
            }
            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault() && newApplication.KolvoCarpet.Text != "0" 
                && int.TryParse(newApplication.KolvoCarpet.Text, out x))
            {
                if(x > 20)
                {
                    MessageBox.Show("Площадь ковра больше 20!");
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
                MessageBox.Show("Введите номер телефона клиента!");
                return false;
            }
            else if (clientPage.Surname.Text == "")
            {
                MessageBox.Show("Укажите фамилию клиента!");
                return false;
            }
            else if(clientPage.Name.Text == "")
            {
                MessageBox.Show("Укажите имя клиента!");
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
                MessageBox.Show("Ни одна из услуг не выбрана");
                return false;
            }
            else if (Order.GetPriceByString(newApplication.PriceBox.Text) == 0)
            {
                MessageBox.Show("Ни одна из услуг не выбрана");
                return false;
            }
            else return true;
        }
    }
}
