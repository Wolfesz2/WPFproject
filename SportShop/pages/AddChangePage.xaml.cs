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
    /// Логика взаимодействия для AddChangePage.xaml
    /// </summary>
    public partial class AddChangePage : Page
    {
        private Product _CurrentProduct = new Product();
        public AddChangePage(Product selectedProduct)
        {
            InitializeComponent();
            if (selectedProduct != null)
                _CurrentProduct = selectedProduct;
            
            DataContext = _CurrentProduct;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_CurrentProduct.Articule))
                errors.AppendLine("Укажите артикуль товара");
            if (string.IsNullOrEmpty(_CurrentProduct.Name))
                errors.AppendLine("Укажите название товара");
            if (string.IsNullOrEmpty(_CurrentProduct.Price.ToString()))
                errors.AppendLine("Укажите цену товара");
            if (string.IsNullOrEmpty(_CurrentProduct.InStock.ToString()))
                errors.AppendLine("Укажите количество товара");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }

            if (_CurrentProduct.Id == 0)
                Entities.GetContext().Product.Add(_CurrentProduct);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
