using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Shopping.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Shopping.Product.Product FindBySku(string sku)
        {
            var productDTO = _eCommerceContext.Products.Include(p => p.ProductCategory).First(p => p.SKU == sku);

            var product = new ECommerceDomain.Shopping.Product.Product(productDTO.Id, productDTO.SKU, productDTO.Manufacturer, productDTO.Description, productDTO.Price, productDTO.CategoryId);

            return product;
        }

        public IList<ECommerceDomain.Shopping.Product.Product> GetAllProducts()
        {
            var productSet = _eCommerceContext.Products.Include(p => p.ProductCategory).ToList();
            var products = new List<ECommerceDomain.Shopping.Product.Product>();

            foreach (var product in productSet)
            {
                products.Add(new ECommerceDomain.Shopping.Product.
                    Product(product.Id, product.SKU, product.Manufacturer, product.Description, product.Price, product.CategoryId));
            }

            return products;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
