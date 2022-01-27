using CleaningDLL.Entity;
using System.Collections.Generic;
using System.Linq;
using WPFCleaning.Admin;

namespace WPFCleaning.AdminFolder.ApplicationsFolder
{
    public class CheckService
    {
        public static void GetCheckedService(int id, ApplicationsFullInfo a)
        {
            List<ProvidedService> pvs = ProvidedService.GetPSByOrder(id);

            foreach (var p in pvs)
            {
                if (p.ServiceID == 1)
                {
                    a.Square.Text = p.Amount.ToString();
                    a.CheckExpressClean.IsChecked = true;
                }
                if (p.ServiceID == 2)
                {
                    a.Square.Text = p.Amount.ToString();
                    a.CheckGeneralClean.IsChecked = true;
                }
                if (p.ServiceID == 3)
                {
                    a.Square.Text = p.Amount.ToString();
                    a.CheckBuildingClean.IsChecked = true;
                }
                if (p.ServiceID == 4)
                {
                    a.Square.Text = p.Amount.ToString();
                    a.CheckOfficeClean.IsChecked = true;
                }
                if (p.ServiceID == 5)
                {
                    a.WindowClean.IsChecked = true;
                    a.KolvoWindow.Text = pvs.Where(a => a.ServiceID == 5).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 6)
                {
                    a.KolvoDoor.Text = pvs.Where(a => a.ServiceID == 6).FirstOrDefault().Amount.ToString();
                    a.WindowClean.IsChecked = true;
                }
                if (p.ServiceID == 7)
                {
                    a.ChemistryClean.IsChecked = true;
                    a.KolvoSofa.Text = pvs.Where(a => a.ServiceID == 7).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 8)
                {
                    a.ChemistryClean.IsChecked = true;
                    a.KolvoArmcheir.Text = pvs.Where(a => a.ServiceID == 8).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 9)
                {
                    a.ChemistryClean.IsChecked = true;
                    a.KolvoCarpet.Text = pvs.Where(a => a.ServiceID == 9).FirstOrDefault().Amount.ToString();
                }
                if (p.ServiceID == 10)
                {
                    a.Dezinfection.IsChecked = true;
                    a.KolvoDezinfection.Text = pvs.Where(a => a.ServiceID == 10).FirstOrDefault().Amount.ToString();
                }
            }
        }
    }
}
