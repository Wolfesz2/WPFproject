
using SportShop.AppData;
using SportShop.DataBase;
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

namespace SportShop.pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {   
        
        public Profile()
        {
            InitializeComponent();
            List<User> list = Entities.GetContext().User.ToList();
            Entities Context = new Entities();
            string text = App.Current.Resources["Login"].ToString();
            int i1 = 0;
            for (int i = 0; i < list.Count; i++)
                if (list[i].Login.ToString() == text)
                {
                    i1 = i;
                    break;
                }
            FamBox.Text = list[i1].Surname;
            NameBox.Text = list[i1].Name;
            MailBox.Text = list[i1].Mail;
            CityBox.Text = list[i1].City;
            StreetBox.Text = list[i1].Street;
            HouseBox.Text = list[i1].House;
            FlatBox.Text = list[i1].Flat;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Entities context = Entities.GetContext();
            string login = App.Current.Resources["Login"].ToString();

            try
            {
                // Найти пользователя по логину
                User userToUpdate = context.User.FirstOrDefault(u => u.Login == login);

                userToUpdate.Surname = FamBox.Text;
                userToUpdate.Name = NameBox.Text;
                userToUpdate.Mail = MailBox.Text;
                userToUpdate.City = CityBox.Text;
                userToUpdate.Street = StreetBox.Text;
                userToUpdate.House = HouseBox.Text;
                userToUpdate.Flat = FlatBox.Text;

                context.SaveChanges();

                MessageBox.Show("Профиль успешно сохранен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.Resources["Role"].ToString() == "3")
            {
                NavigationService.Navigate(new UserMenu());
            }
            else
            {
                NavigationService.Navigate(new MAMenu());
            }
        }
    }
}
