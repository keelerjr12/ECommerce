using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.ProductService
{
    public class TopSellingProductsQueryHandler : IRequestHandler<TopSellingProductsQuery, TopSellingProductsResult>
    {
        public TopSellingProductsQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<TopSellingProductsResult> Handle(TopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            var quantityOfProducts = new Dictionary<ECommerceData.Product.ProductDTO, int>();

            foreach (var product in _db.Products)
            {
                var quantity = GetQuantityOrdered(product.SKU);
                quantityOfProducts.Add(product, quantity);
            }

            var sortedProductPairs = quantityOfProducts.OrderByDescending(p => p.Value);

            var topSellers = new List<ProductDTO>();
            foreach (var sortedPair in sortedProductPairs.Take(request.NumberOfProducts))
            {
                var product = sortedPair.Key;

                var productDTO = new ProductDTO(product.SKU, product.Description, product.Price);

                topSellers.Add(productDTO);
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
