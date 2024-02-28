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
    /// Логика взаимодействия для EditProductList.xaml
    /// </summary>
    public partial class EditProductList : Page
    {
        public EditProductList()
        {
            InitializeComponent();

            DataProducts.ItemsSource = Entities.GetContext().Product.ToList();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddChangePage((sender as Button).DataContext as Product));
        }

        private void AddRawButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddChangePage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataProducts.ItemsSource = Entities.GetContext().Product.ToList();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MAMenu());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var ProductForRemove = DataProducts.SelectedItems.Cast<Product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ProductForRemove.Count()} элементов?","Внимание",
                MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.GetContext().Product.RemoveRange(ProductForRemove);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DataProducts.ItemsSource = Entities.GetContext().Product.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
