using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kr3
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private int failedAtt = 0;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            Users guestUser = new Users
            {
                UserID = 0,
                Login = "guest",
                FirstName = "Гость",
                SecondName = "",
                Patronymic = "",
                RoleID = 0

            };
            Manager.MainFrame.Navigate(new ProductPage(guestUser));
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Введите логин!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Users users = kr_chudo_obuvEntities.GetContext().Users
                .FirstOrDefault(p => p.Login == LoginTB.Text);

            if (users != null)
            {
                LoginTB.Text = "";
                Manager.MainFrame.Navigate(new ProductPage(users));
            }
            else
            {
                failedAtt++;

                if (failedAtt > 0)
                {
                    MessageBox.Show("Введены неверные данные!",
                                  "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                LoginTB.Text = "";
            }
        }
    }
}
