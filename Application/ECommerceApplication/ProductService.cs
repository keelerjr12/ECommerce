using System.Collections.Generic;
using ECommerceDomain.Product;

namespace ECommerceApplication
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product> { new Product("1", "This is a test", 10.2m), new Product("2", "another test", 32m) };
        }
    }
}
