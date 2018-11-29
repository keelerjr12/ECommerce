using System.Collections.Generic;
using ECommerceDomain.Product;

namespace ECommerceApplication
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product> { new Product("2", "shinydiamond " , 32m, "bracelet") };
        }
    }
}
