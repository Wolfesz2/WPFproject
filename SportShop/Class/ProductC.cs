using SportShop.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SportShop.Class
{
    public class ProductC
    {
        public string ArticuleC { get; set; }
        public string NameC { get; set; }
        public string DescriptionC { get; set; }
        public decimal PriceC { get; set; }
        public int InStockC { get; set; }
        public ProductC(Product product)
        {
            ArticuleC = product.Articule;
            NameC = product.Name;
            DescriptionC = product.Description;
            PriceC = int.Parse(product.Price.ToString());
            InStockC = int.Parse(product.InStock.ToString());
        }
    }
}
