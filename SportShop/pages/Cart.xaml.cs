using SportShop.Class;
using SportShop.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        private ObservableCollection<ProductC> cartItems;
        public Cart(ObservableCollection<ProductC> cartItems)
        {
            InitializeComponent();
            this.cartItems = cartItems;
            CartProducts.ItemsSource = cartItems;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = CartProducts.SelectedItems.Cast<ProductC>().ToList();
            foreach (var selectedItem in selectedItems)
            {
                cartItems.Remove(selectedItem);
            }
        }

        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            cartItems.Clear();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
