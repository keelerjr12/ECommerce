using System.Collections.Generic;
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

            foreach (var product in products)
            {
                var ordered =_orderService.GetQuantityOrdered(product.SKU);
            }

            return products;
        }

        private readonly IProductRepository _productRepo;
        private readonly OrderService _orderService;
    }
}
