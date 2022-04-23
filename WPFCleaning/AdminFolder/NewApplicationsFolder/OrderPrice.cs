using System;
using System.Windows;
using System.Windows.Controls;
using CleaningDLL.Entity;
using System.Collections.Generic;
using System.Linq;
//Класс реализующий расчет стоимости и времени оказания услуг
namespace WPFCleaning.Admin
{
    public static class OrderPrice
    {
        public static int[,] arrayService = new int[2, 7];

        public static void Calculate(NewApplication newApplication, ClientPage clientPage, string selectedItems = "")
        {
            Array.Clear(arrayService, 0, arrayService.Length);
            arrayService[0, 1] = Service.GetIdService("Мойка окон");
            arrayService[0, 2] = Service.GetIdService("Мойка стеклянных дверей");
            arrayService[0, 3] = Service.GetIdService("Химчистка диванов");
            arrayService[0, 4] = Service.GetIdService("Химчистка кресел");
            arrayService[0, 5] = Service.GetIdService("Химчистка ковров");
            arrayService[0, 6] = Service.GetIdService("Дезинфекция");

            newApplication.PriceBox.Text = "";
            newApplication.ApproximateTime.Text = "";
            newApplication.finalPrice = 0;
            newApplication.approximateTime = 0;

            List<CheckBox> checkBoxes = GetCheckBoxIsChecked(newApplication);
            if(checkBoxes.Count != 0)
            {
                if (checkBoxes[0].Name == newApplication.CheckExpressClean.Name ||
                    checkBoxes[0].Name == newApplication.CheckGeneralClean.Name ||
                    checkBoxes[0].Name == newApplication.CheckBuildingClean.Name ||
                    checkBoxes[0].Name == newApplication.CheckComplexСleaningClean.Name)
                {
                    if (newApplication.TextBoxSquare.Text != "")
                    {
                        arrayService[0, 0] = (Service.GetIdService(checkBoxes[0].Content.ToString()));
                        arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                        newApplication.finalPrice += Service.GetServiceById(Service.GetIdService(checkBoxes[0].Content.ToString())).Price
                            * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                        newApplication.approximateTime += Service.GetServiceById(Service.GetIdService(checkBoxes[0].Content.ToString())).Time
                            * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                    }
                    else
                    {
                        checkBoxes[0].IsChecked = false;
                        MessageBox.Show("Введите площадь");
                        checkBoxes.RemoveAll(e => e.IsChecked.GetValueOrDefault());
                    }
                    checkBoxes.RemoveAt(0);
                }
                
                decimal tmpPrice = newApplication.finalPrice;
                int tmpApproximateTime = newApplication.approximateTime;
                foreach (var checkBox in checkBoxes)
                {
                    newApplication.finalPrice = tmpPrice;
                    newApplication.approximateTime = tmpApproximateTime;

                    List<int> quantityService = GetTextFromTextBox(newApplication);
                    for (int i = 1; i <= 6; i++)
                    {
                        arrayService[1, i] = quantityService[i - 1];
                        newApplication.finalPrice += quantityService[i - 1] * Service.GetServiceById(arrayService[0, i]).Price;
                        newApplication.approximateTime += quantityService[i - 1] * Service.GetServiceById(arrayService[0, i]).Time;
                    }
                    
                }
                if (clientPage.CheckOldClient.IsChecked.GetValueOrDefault())
                {
                    newApplication.finalPrice = Convert.ToInt32((newApplication.finalPrice * 90) / 100);
                }

                RoomType roomType = RoomType.GetСoefficientByType(selectedItems);
                newApplication.finalPrice *= roomType.Сoefficient;

                newApplication.PriceBox.Text = Order.GetPriceByInt(Convert.ToInt32(newApplication.finalPrice));
                newApplication.ApproximateTime.Text = Order.GetTimeByInt(newApplication.approximateTime);
            }
            
        }
        public static List<CheckBox> GetCheckBoxIsChecked(NewApplication newApplication)
        {
            List<CheckBox> list = new List<CheckBox>();
            list.Add(newApplication.CheckExpressClean);
            list.Add(newApplication.CheckGeneralClean);
            list.Add(newApplication.CheckBuildingClean);
            list.Add(newApplication.CheckComplexСleaningClean);
            list.Add(newApplication.ChemistryClean);
            list.Add(newApplication.WindowClean);
            list.Add(newApplication.Dezinfection);

            return list.Where(c => c.IsChecked.GetValueOrDefault()).ToList();
        }

        public static List<int> GetTextFromTextBox(NewApplication newApplication)
        {
            List<int> list = new List<int>();
            list.Add(Convert.ToInt32(newApplication.KolvoWindow.Text));
            list.Add(Convert.ToInt32(newApplication.KolvoDoor.Text));
            list.Add(Convert.ToInt32(newApplication.KolvoSofa.Text));
            list.Add(Convert.ToInt32(newApplication.KolvoArmcheir.Text));
            list.Add(Convert.ToInt32(newApplication.KolvoCarpet.Text));
            list.Add(Convert.ToInt32(newApplication.KolvoDezinfection.Text));

            return list;
        }
    }
}
