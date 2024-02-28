using SportShop.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace SportShop.pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static string loginUser;
        public Authorization()
        {
            InitializeComponent();
            App.Current.Resources["Login"] = "";
            App.Current.Resources["Role"] = "";
            
        }
        
        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var userObj = AppConnect.model.User.FirstOrDefault(x => x.Login == LoginBox.Text && x.Password == PassBox.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (userObj.RoleId == 3)
                {
                    App.Current.Resources["Role"] = "3";
                    App.Current.Resources["Login"] = LoginBox.Text;
                    NavigationService.Navigate(new UserMenu());
                }
                else if (userObj.RoleId == 1 || userObj.RoleId == 2)
                {
                    App.Current.Resources["Login"] = "2";
                    App.Current.Resources["Login"] = LoginBox.Text;
                    NavigationService.Navigate(new MAMenu());
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + " Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
