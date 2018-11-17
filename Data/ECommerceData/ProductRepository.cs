using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Product;

namespace ECommerceData
{
    public class ProductRepository : IProductRepository
    {
        public Product FindBySku(string sku)
        {
            return _products.Find(prod => prod.SKU == sku);
        }

        public IReadOnlyList<Product> GetAllProducts()
        {
            return _products.ToList();
        }

        private List<Product> _products = new List<Product>()
        {
            new Product("232097127182", "Sony", "Sony 85\" HDTV", 1999.99m),
            new Product("230952093785", "Samsung", "Samsung 65\" 4K UHDTV", 1599.95m)
        };
    }
}
