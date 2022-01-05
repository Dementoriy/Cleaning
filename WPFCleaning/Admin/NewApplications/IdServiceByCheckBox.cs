using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    public static class IdServiceByCheckBox
    {
        public static int[,] arrayService = new int[2, 7];
        public static int GetServiceByCheckBox(NewApplication newApplication)
        {
            if (newApplication.CheckExpressClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckExpressClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                return Service.GetIdService(newApplication.CheckExpressClean.Content.ToString());
            }

            if (newApplication.CheckGeneralClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckGeneralClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                return Service.GetIdService(newApplication.CheckGeneralClean.Content.ToString());
            }

            if (newApplication.CheckBuildingClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckBuildingClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                return Service.GetIdService(newApplication.CheckBuildingClean.Content.ToString());
            }
            if (newApplication.CheckOfficeClean.IsChecked.GetValueOrDefault())
            {
                arrayService[0, 0] = (Service.GetIdService(newApplication.CheckOfficeClean.Content.ToString()));
                arrayService[1, 0] = Convert.ToInt32(newApplication.TextBoxSquare.Text);
                return Service.GetIdService(newApplication.CheckOfficeClean.Content.ToString());
            }
            return 0;
        }
    }
}
