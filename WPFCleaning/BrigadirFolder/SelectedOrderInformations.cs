using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;
using System.Collections.Generic;
using System.Linq;

namespace WPFCleaning.Brigadir
{
    public static class SelectedOrderInformations
    {
        public static void GetSelectOrderInfo(BrigadeApplications ba, Employee _br)
        {
            List<Order.OrderInfo> listSort = Order.GetOrderInfo();
            if (ba.CheckFinish.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Завершена").ToList();
            }
            else if (ba.CheckInProcess.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "В процессе").ToList();
            }
            else if (ba.CheckWait.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Ожидает").ToList();
            }
            if (ba.DatePickerSearchEnd.Text != "" && ba.DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = ba.DatePickerSearchStart.SelectedDate.Value;
                DateTime dtEnd = ba.DatePickerSearchEnd.SelectedDate.Value;

                if (ba.DatePickerSearchStart.SelectedDate.Value <= ba.DatePickerSearchEnd.SelectedDate.Value)
                    listSort = listSort = listSort.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();
                else
                {
                    MessageBox.Show("Дата конца периода больше \n даты начала периода");
                    ba.DatePickerSearchEnd.Text = "";
                }

            }
            if (ba.DatePickerSearchStart.Text == "")
            {
                listSort = listSort.ToList();
            }
            if (ba.DatePickerSearchEnd.Text == "" && ba.DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = ba.DatePickerSearchStart.SelectedDate.Value;

                listSort = listSort.Where(e => DateTime.Parse(e.Date) == dtStart.Date).ToList();
            }
            if (ba.SearchBox.Text != "")
            {
                listSort = listSort.Where(e => e.Address.ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Telefone.ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Client.ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Brigade.ToString().ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Date.ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Time.ToLower().Contains(ba.SearchBox.Text.ToLower())
                || e.Status.ToLower().Contains(ba.SearchBox.Text.ToLower())
                ).ToList();
            }
            ba.dataGridApplication.ItemsSource = listSort.Where(d => d.Brigade == _br.BrigadeID);
        }
    }
}
