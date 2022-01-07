using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    public static class OrderPrice
    {
        public static int[,] arrayService = new int[2, 7];
        public static void Calculate(NewApplication newApplication, ClientPage clientPage)
        {
            Array.Clear(arrayService, 0, arrayService.Length);

            newApplication.PriceBox.Text = "";
            newApplication.ApproximateTime.Text = "";
            newApplication.finalPrice = 0;
            newApplication.approximateTime = 0;

            if (newApplication.CheckExpressClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckExpressClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.finalPrice += Service.GetServiceById(Service.GetIdService(newApplication.CheckExpressClean.Content.ToString())).Price
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.approximateTime += Service.GetServiceById(Service.GetIdService(newApplication.CheckExpressClean.Content.ToString())).Time
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
            }
            if (newApplication.CheckGeneralClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckGeneralClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.finalPrice += Service.GetServiceById(Service.GetIdService(newApplication.CheckGeneralClean.Content.ToString())).Price
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.approximateTime += Service.GetServiceById(Service.GetIdService(newApplication.CheckGeneralClean.Content.ToString())).Time
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
            }
            if (newApplication.CheckBuildingClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckBuildingClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.finalPrice += Service.GetServiceById(Service.GetIdService(newApplication.CheckBuildingClean.Content.ToString())).Price
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.approximateTime += Service.GetServiceById(Service.GetIdService(newApplication.CheckBuildingClean.Content.ToString())).Time
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
            }
            if (newApplication.CheckOfficeClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckOfficeClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.finalPrice += Service.GetServiceById(Service.GetIdService(newApplication.CheckOfficeClean.Content.ToString())).Price
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
                newApplication.approximateTime += Service.GetServiceById(Service.GetIdService(newApplication.CheckOfficeClean.Content.ToString())).Time
                    * Convert.ToInt32(newApplication.TextBoxSquare.Text);
            }

            if (newApplication.WindowClean.IsChecked.GetValueOrDefault())
            {
                if (newApplication.KolvoWindow.Text != "")
                {
                    string str = "Мойка окон";
                    newApplication.idService = Service.GetIdService(str);

                    arrayService[0, 1] = newApplication.idService;
                    arrayService[1, 1] = Convert.ToInt32(newApplication.KolvoWindow.Text);
                    newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoWindow.Text) * Service.GetServiceById(newApplication.idService).Price;
                    newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoWindow.Text) * Service.GetServiceById(newApplication.idService).Time;
                }
                if (newApplication.KolvoDoor.Text != "")
                {
                    string str = "Мойка стеклянных дверей";
                    newApplication.idService = Service.GetIdService(str);

                    arrayService[0, 2] = newApplication.idService;
                    arrayService[1, 2] = Convert.ToInt32(newApplication.KolvoDoor.Text);
                    newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoDoor.Text) * Service.GetServiceById(newApplication.idService).Price;
                    newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoDoor.Text) * Service.GetServiceById(newApplication.idService).Time;
                }
            }

            if (newApplication.ChemistryClean.IsChecked.GetValueOrDefault())
            {
                if (newApplication.KolvoSofa.Text != "")
                {
                    string str = "Химчистка диванов";
                    newApplication.idService = Service.GetIdService(str);

                    arrayService[0, 3] = newApplication.idService;
                    arrayService[1, 3] = Convert.ToInt32(newApplication.KolvoSofa.Text);
                    newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoSofa.Text) * Service.GetServiceById(newApplication.idService).Price;
                    newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoSofa.Text) * Service.GetServiceById(newApplication.idService).Time;
                }
                if (newApplication.KolvoArmcheir.Text != "")
                {
                    string str = "Химчистка кресел";
                    newApplication.idService = Service.GetIdService(str);

                    arrayService[0, 4] = newApplication.idService;
                    arrayService[1, 4] = Convert.ToInt32(newApplication.KolvoArmcheir.Text);
                    newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoArmcheir.Text) * Service.GetServiceById(newApplication.idService).Price;
                    newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoArmcheir.Text) * Service.GetServiceById(newApplication.idService).Time;
                }
                if (newApplication.KolvoCarpet.Text != "")
                {
                    string str = "Химчистка ковров";
                    newApplication.idService = Service.GetIdService(str);

                    arrayService[0, 5] = newApplication.idService;
                    arrayService[1, 5] = Convert.ToInt32(newApplication.KolvoCarpet.Text);
                    newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoCarpet.Text) * Service.GetServiceById(newApplication.idService).Price;
                    newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoCarpet.Text) * Service.GetServiceById(newApplication.idService).Time;
                }
            }
            if (newApplication.Dezinfection.IsChecked.GetValueOrDefault())
            {
                string str = "Дезинфекция";
                newApplication.idService = Service.GetIdService(str);

                arrayService[0, 6] = newApplication.idService;
                arrayService[1, 6] = Convert.ToInt32(newApplication.KolvoDezinfection.Text);
                newApplication.finalPrice += Convert.ToInt32(newApplication.KolvoDezinfection.Text) * Service.GetServiceById(newApplication.idService).Price;
                newApplication.approximateTime += Convert.ToInt32(newApplication.KolvoDezinfection.Text) * Service.GetServiceById(newApplication.idService).Time;
            }

            if (clientPage.CheckOldClient.IsChecked.GetValueOrDefault())
            {
                newApplication.finalPrice = Convert.ToInt32((newApplication.finalPrice * 90) / 100);
            }

            newApplication.at = newApplication.approximateTime;

            newApplication.PriceBox.Text = newApplication.finalPrice.ToString();
            newApplication.ApproximateTime.Text = Order.GetTimeByInt(newApplication.approximateTime);
        }
    }
}
