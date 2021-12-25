using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using CleaningDLL;
using CleaningDLL.Entity;
using WPFCleaning.Admin;
using WPFCleaning.Brigadir;

namespace WPFCleaning
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class AuthorizationWindow
    {
        public AuthorizationWindow()
        {
            new ApplicationContext(ApplicationContext.GetDb());
            Order.CheckOrder();
            InitializeComponent();
        }
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = Employee.GetEmployee(TextBoxLogin.Text.Trim(), GetHash(PasswordBox.Password.Trim()));

            if (employee != null)
            {
                if (employee.PositionID == 1)
                {
                    MainWindow mainWindow = new MainWindow(employee);
                    mainWindow.Show();
                    this.Close();
                }
                else if (employee.PositionID == 2)
                {
                    BrigadirWindow brigadirWindow = new BrigadirWindow(employee);
                    brigadirWindow.Show();
                    this.Close();
                }
            }
            else MessageBox.Show("Введен неверный логин или пароль.\n Повторите попытку.");
        }
        private static string GetHash(string input)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
