using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Product;

namespace ECommerceData.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Sales.Product.Product FindBySku(string sku)
        {
            var productDTO = _eCommerceContext.Products.First(p => p.SKU == sku);

            var product = new ECommerceDomain.Sales.Product.Product(productDTO.SKU, productDTO.Manufacturer, productDTO.Description, productDTO.Price, productDTO.Category);

            return product;
        }

        public IList<ECommerceDomain.Sales.Product.Product> GetAllProducts()
        {
            var productSet = _eCommerceContext.Products.ToList();
            var products = new List<ECommerceDomain.Sales.Product.Product>();

            foreach (var product in productSet)
            {
                products.Add(new ECommerceDomain.Sales.Product.
                    Product(product.SKU, product.Manufacturer, product.Description, product.Price, product.Category));
            }

            return products;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
