using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CleaningDLL.Entity;
using CleaningDLL;

namespace WPFCleaning.Admin
{
    public static class CorrectTime
    {
        public static void PreviewTextInput(NewApplication newApplication, TextCompositionEventArgs e)
        {
            string tt = newApplication.SelectTime.Text;
            int val;

            if (tt.Length == 2)
            {
                newApplication.SelectTime.Text = tt + ":";
                newApplication.SelectTime.SelectionStart = newApplication.SelectTime.Text.Length; //коретка в конец строки
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
        public static void TextChanged(NewApplication newApplication)
        {
            string tt = newApplication.SelectTime.Text;

            if (tt.Length == 1)
            {
                if (Convert.ToInt32(tt) > 2)
                {
                    newApplication.SelectTime.Text = "0" + tt;
                    newApplication.SelectTime.SelectionStart = newApplication.SelectTime.Text.Length;
                }
            }
            if (tt.Length == 2)
            {
                if (Convert.ToInt32(tt.Substring(0, 2)) > 23)
                {
                    newApplication.SelectTime.Text = tt.Remove(1, 1);
                    newApplication.SelectTime.SelectionStart = newApplication.SelectTime.Text.Length;
                }
            }
            if (tt.Length == 4)
            {
                if (Convert.ToInt32(tt.Substring(3, 1)) > 5)
                {
                    newApplication.SelectTime.Text = tt.Substring(0, 3) + "0" + tt.Substring(3, 1);
                    newApplication.SelectTime.SelectionStart = newApplication.SelectTime.Text.Length;
                }
            }
        }
    }
}
