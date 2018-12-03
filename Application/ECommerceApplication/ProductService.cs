using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Product;

namespace ECommerceApplication
{
    public class ProductService
    {
        public ProductService(IProductRepository productRepo, OrderService orderService)
        {
            _productRepo = productRepo;
            _orderService = orderService;
        }

        public IList<Product> GetAllProducts()
        {
            return _productRepo.GetAllProducts();
        }

        public IEnumerable<Product> GetTopSellingProducts(int numberOfProducts)
        {
            var products = GetAllProducts();
            var quantityOfProducts = new Dictionary<Product, int>();

            foreach (var product in products)
            {
                var quantity =_orderService.GetQuantityOrdered(product.SKU);
                quantityOfProducts.Add(product, quantity);
            }

            var sortedProductPairs = quantityOfProducts.OrderByDescending(p => p.Value);

            var topSellers = new List<Product>();
            foreach (var sortedPair in sortedProductPairs.Take(numberOfProducts))
            {
                topSellers.Add(sortedPair.Key);
            }

            return topSellers;
        }

        private readonly IProductRepository _productRepo;
        private readonly OrderService _orderService;
    }
}
