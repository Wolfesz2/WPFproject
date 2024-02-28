using SportShop.AppData;
using SportShop.Class;
using SportShop.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public partial class ProductList : Page
    {
        private ObservableCollection<Product> cartItems = new ObservableCollection<Product>();

        public ProductList()
        {
            InitializeComponent();
            DataProducts.ItemsSource = Entities.GetContext().Product.ToList();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = (Product)DataProducts.SelectedItem;

            if (selectedProduct != null)
            {
                
                cartItems.Add(selectedProduct);
            }
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            var cartItemsC = new ObservableCollection<ProductC>(
           cartItems.Select(product => ConvertToProductC(product))
       );

            Cart cartPage = new Cart(cartItemsC);
            NavigationService.Navigate(cartPage);
        }

        private ProductC ConvertToProductC(Product product)
        {
            return new ProductC(product);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenu());
        }
    }
}
