using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CleaningDLL;
using CleaningDLL.Entity;

namespace WPFCleaning.Admin
{
    public static class ChangeOrder
    {
        public static void PreviewTextInput(ApplicationsFullInfo afi, TextCompositionEventArgs e)
        {
            string tt = afi.SelectTime.Text;
            int val;

            if (tt.Length == 2)
            {
                afi.SelectTime.Text = tt + ":";
                afi.SelectTime.SelectionStart = afi.SelectTime.Text.Length; //коретка в конец строки
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

        public static void TextChanged(ApplicationsFullInfo afi)
        {
            string tt = afi.SelectTime.Text;

            if (tt.Length == 1)
            {
                if (Convert.ToInt32(tt) > 2)
                {
                    afi.SelectTime.Text = "0" + tt;
                    afi.SelectTime.SelectionStart = afi.SelectTime.Text.Length;
                }
            }
            if (tt.Length == 2)
            {
                if (Convert.ToInt32(tt.Substring(0, 2)) > 23)
                {
                    afi.SelectTime.Text = tt.Remove(1, 1);
                    afi.SelectTime.SelectionStart = afi.SelectTime.Text.Length;
                }
            }
            if (tt.Length == 4)
            {
                if (Convert.ToInt32(tt.Substring(3, 1)) > 5)
                {
                    afi.SelectTime.Text = tt.Substring(0, 3) + "0" + tt.Substring(3, 1);
                    afi.SelectTime.SelectionStart = afi.SelectTime.Text.Length;
                }
            }
        }
    }
}
