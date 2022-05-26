using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using CleaningDLL.Entity;
using Microsoft.Win32;
using System.IO;
using NPOI.XSSF.UserModel;

namespace WPFCleaning.Admin
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
            AddAplication();
            SelectedOrderInfo();
            CheckFinish.IsChecked = true;
        }

        public void AddAplication()
        {
            dataGridOrder.ItemsSource = Order.GetOrderInfo();
        }

        private void CheckFinish_Checked(object sender, RoutedEventArgs e)
        {
            CheckCanceled.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckFinish_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckCanceled.IsChecked.GetValueOrDefault())
                SelectedOrderInfo();
        }
        private void CheckCanceled_Checked(object sender, RoutedEventArgs e)
        {
            CheckFinish.IsChecked = false;
            SelectedOrderInfo();
        }
        private void CheckCanceled_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckFinish.IsChecked.GetValueOrDefault())
                SelectedOrderInfo();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private IEnumerable<Order.OrderInfo> _listSort;

        public void SelectedOrderInfo()
        {
            var listSort = Order.GetOrderInfo();
            if (CheckFinish.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Завершена").ToList();
            }
            else if (CheckCanceled.IsChecked == true)
            {
                listSort = listSort.Where(e => e.Status == "Отменена").ToList();
            }
            if (DatePickerSearchEnd.Text != "" && DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;
                DateTime dtEnd = DatePickerSearchEnd.SelectedDate.Value;

                if (DatePickerSearchStart.SelectedDate.Value <= DatePickerSearchEnd.SelectedDate.Value)
                    listSort = listSort.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();
                else
                {
                    MessageBox.Show("Дата конца периода больше \n даты начала периода");
                    DatePickerSearchEnd.Text = "";
                }

            }
            if (DatePickerSearchStart.Text == "")
            {
                listSort = listSort.ToList();
            }
            if (DatePickerSearchEnd.Text == "" && DatePickerSearchStart.Text != "")
            {
                DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;

                listSort = listSort.Where(e => DateTime.Parse(e.Date) == dtStart.Date).ToList();
            }
            if (SearchBox.Text != "")
            {
                listSort = listSort.Where(e => e.Address.ToLower().Contains(SearchBox.Text.ToLower())
                || e.FinalPrice.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.ApproximateTime.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Brigade.ToString().ToLower().Contains(SearchBox.Text.ToLower())
                || e.Date.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Time.ToLower().Contains(SearchBox.Text.ToLower())
                || e.Status.ToLower().Contains(SearchBox.Text.ToLower())
                ).ToList();
            }
            _listSort = listSort;
            dataGridOrder.ItemsSource = listSort;
        }
        private void DatePickerSearchStart_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }
        private void DatePickerSearchEnd_CalendarClosed(object sender, RoutedEventArgs e)
        {
            SelectedOrderInfo();
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectedOrderInfo();
        }

        private void DelDateStartButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearchStart.Text != "")
            {
                DatePickerSearchStart.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }
        private void DelDateEndButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePickerSearchEnd.Text != "")
            {
                DatePickerSearchEnd.Text = "";
                SelectedOrderInfo();
            }
            else
                SelectedOrderInfo();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order.OrderInfo selectedOrder = (Order.OrderInfo)dataGridOrder.SelectedValue;
            ApplicationsFullInfo applicationsFullInfo = new ApplicationsFullInfo(selectedOrder.ID, default);
            applicationsFullInfo.Show();
            applicationsFullInfo.AddSelectedOrder();
        }

        private void CalculateReport_Click(object sender, RoutedEventArgs e)
        {
            List<Order> orders = new List<Order>();
            int fp = 0;
            int sec = 0;

            foreach (Order.OrderInfo order in _listSort)
            {
                orders.Add(Order.GetOrderById(order.ID));
            }
            foreach (Order order in orders)
            {
                fp += order.FinalPrice;
                sec += order.ApproximateTime;
            }
            KolvoOrderBox.Text = orders.Count().ToString();
            KolvoTimeBox.Text = Order.GetTimeByInt(sec);
            PriceBox.Text = Order.GetPriceByInt(fp);
        }
        private void DatePickerSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text != ".")
            {
                e.Handled = true; // отклоняем ввод
            }
        }

        private void ToReportBtn(object sender, RoutedEventArgs e)
        {

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment
            .GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExt = ".xlsx";
            dialog.Filter =
            "Таблицы Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.FileName = "Отчет";
            if (dialog.ShowDialog() == true)
            {
                var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                var template = new MemoryStream(Properties.Resources.Shablon, true);
                var workbook = new XSSFWorkbook(template);
                var sheet = workbook.GetSheetAt(0);


                sheet.GetRow(6).CreateCell(7);
                sheet.GetRow(7).CreateCell(2);
                sheet.GetRow(7).CreateCell(7);
                sheet.GetRow(8).CreateCell(2);
                sheet.GetRow(8).CreateCell(7);

                sheet.GetRow(2).GetCell(7).SetCellValue(DateTime.Today.ToShortDateString());
                sheet.GetRow(7).GetCell(2).SetCellValue(DatePickerSearchStart.Text);
                sheet.GetRow(8).GetCell(2).SetCellValue(DatePickerSearchEnd.Text);
                sheet.GetRow(6).GetCell(7).SetCellValue(KolvoOrderBox.Text);
                sheet.GetRow(7).GetCell(7).SetCellValue(KolvoTimeBox.Text);
                sheet.GetRow(8).GetCell(7).SetCellValue(PriceBox.Text);

                sheet.ShiftRows(11, 11 + int.Parse(KolvoOrderBox.Text), int.Parse(KolvoOrderBox.Text), true, true);
                int row = 11;

                var listSort = Order.GetOrderInfo();

                if (DatePickerSearchEnd.Text != "" && DatePickerSearchStart.Text != "")
                {
                    DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;
                    DateTime dtEnd = DatePickerSearchEnd.SelectedDate.Value;

                    if (DatePickerSearchStart.SelectedDate.Value <= DatePickerSearchEnd.SelectedDate.Value)
                        listSort = listSort.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();
                    else
                    {
                        MessageBox.Show("Дата конца периода больше \n даты начала периода");
                        DatePickerSearchEnd.Text = "";
                    }
                    if (CheckFinish.IsChecked == true)
                    {
                        listSort = listSort.Where(e => e.Status == "Завершена").ToList();
                    }
                    else if (CheckCanceled.IsChecked == true)
                    {
                        listSort = listSort.Where(e => e.Status == "Отменена").ToList();
                    }

                    foreach (var item in listSort.OrderBy(x => x.ID))
                    {
                        var rowInsert = sheet.CreateRow(row);
                        rowInsert.CreateCell(0).SetCellValue(row - 10);
                        rowInsert.GetCell(0).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(1).SetCellValue(item.ID);
                        rowInsert.GetCell(1).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(2).SetCellValue(item.Date);
                        rowInsert.GetCell(2).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(3).SetCellValue(item.Time);
                        rowInsert.GetCell(3).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(4).SetCellValue(item.Address);
                        rowInsert.GetCell(4).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(5).SetCellValue(item.Status);
                        rowInsert.GetCell(5).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(6).SetCellValue(item.Brigade);
                        rowInsert.GetCell(6).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(7).SetCellValue(item.FinalPrice);
                        rowInsert.GetCell(7).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        rowInsert.CreateCell(8).SetCellValue(item.ApproximateTime);
                        rowInsert.GetCell(8).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                        row++;
                    }

                    workbook.Write(file);
                    MessageBox.Show("Отчет успешно создан");
                }
        }
        //private void ToReportBtn(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog dialog = new SaveFileDialog();
        //    dialog.InitialDirectory = Environment
        //    .GetFolderPath(Environment.SpecialFolder.Desktop);
        //    dialog.DefaultExt = ".xlsx";
        //    dialog.Filter = "Таблицы Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
        //    dialog.FilterIndex = 1;
        //    dialog.FileName = "Отчет";
        //    if (dialog.ShowDialog() == true)
        //    {
        //        var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
        //        var template = new MemoryStream(Properties.Resources.Shablon, true);
        //        var workbook = new XSSFWorkbook(template);
        //        var sheet = workbook.GetSheetAt(0);

        //        sheet.GetRow(2).GetCell(7).SetCellValue(DateTime.Today.ToShortDateString());

        //        sheet.GetRow(6).GetCell(7).SetCellValue(KolvoOrderBox.Text);
        //        sheet.GetRow(7).GetCell(7).SetCellValue(KolvoTimeBox.Text);
        //        sheet.GetRow(8).GetCell(7).SetCellValue(PriceBox.Text);

        //        sheet.ShiftRows(11, 11 + int.Parse(KolvoOrderBox.Text), int.Parse(KolvoOrderBox.Text), true, true);
        //        int row = 11;

        //        var listSort = Order.GetOrderInfo();

        //        if (DatePickerSearchEnd.Text != "" && DatePickerSearchStart.Text != "")
        //        {
        //            DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;
        //            DateTime dtEnd = DatePickerSearchEnd.SelectedDate.Value;

        //            if (DatePickerSearchStart.SelectedDate.Value <= DatePickerSearchEnd.SelectedDate.Value)
        //                listSort = listSort.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();
        //            else
        //            {
        //                MessageBox.Show("Дата конца периода больше \n даты начала периода");
        //                DatePickerSearchEnd.Text = "";
        //            }
        //            if (CheckFinish.IsChecked == true)
        //            {
        //                listSort = listSort.Where(e => e.Status == "Завершена").ToList();
        //            }
        //            else if (CheckCanceled.IsChecked == true)
        //            {
        //                listSort = listSort.Where(e => e.Status == "Отменена").ToList();
        //            }

        //            foreach (var item in listSort.OrderBy(x => x.ID))
        //            {
        //                var rowInsert = sheet.CreateRow(row);
        //                rowInsert.CreateCell(0).SetCellValue(row - 10);
        //                rowInsert.GetCell(0).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(1).SetCellValue(item.ID);
        //                rowInsert.GetCell(1).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(2).SetCellValue(item.Date);
        //                rowInsert.GetCell(2).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(3).SetCellValue(item.Time);
        //                rowInsert.GetCell(3).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(4).SetCellValue(item.Address);
        //                rowInsert.GetCell(4).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(5).SetCellValue(item.Status);
        //                rowInsert.GetCell(5).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(6).SetCellValue(item.Brigade);
        //                rowInsert.GetCell(6).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(7).SetCellValue(item.FinalPrice);
        //                rowInsert.GetCell(7).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                rowInsert.CreateCell(8).SetCellValue(item.ApproximateTime);
        //                rowInsert.GetCell(8).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
        //                row++;
        //            }

        //            workbook.Write(file);
        //        }
        //   }
        }
    }
}
