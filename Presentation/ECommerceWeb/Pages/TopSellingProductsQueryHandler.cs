using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceData.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Pages
{
    public class TopSellingProductsQueryHandler : IRequestHandler<TopSellingProductsQuery, TopSellingProductsResult>
    {
        public TopSellingProductsQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<TopSellingProductsResult> Handle(TopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            var quantityOfProducts = new Dictionary<ProductDTO, int>();

            foreach (var product in _db.Products)
            {
                var quantity = GetQuantityOrdered(product.SKU);
                quantityOfProducts.Add(product, quantity);
            }

            var sortedProductPairs = quantityOfProducts.OrderByDescending(p => p.Value);

            var topSellers = new List<ProductViewModel>();
            foreach (var sortedPair in sortedProductPairs.Take(request.NumberOfProducts))
            {
                var product = sortedPair.Key;

                var productVM = new ProductViewModel
                {
                    SKU = product.SKU,
                    Description = product.Description,
                    Price = product.Price
                };

                topSellers.Add(productVM);
            }

            var result = new TopSellingProductsResult
            {
                Products = topSellers
            };
            
            return result;
        }

        private int GetQuantityOrdered(string sku)
        {
            var quantity = 0;

            foreach(var order in _db.Orders.Include(o => o.OrderLines))
            {
                foreach (var orderLine in order.OrderLines)
                {
                    if (orderLine.SKU == sku)
                    {
                        quantity++;
                    }
                }
            }

            return quantity;
        }

        private readonly ECommerceContext _db;
    }
}
