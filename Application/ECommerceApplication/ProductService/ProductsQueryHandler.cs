using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.ProductService
{
    public class ProductsQueryHandler : IRequestHandler<ProductsQuery, ProductsResult>
    {
        public ProductsQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<ProductsResult> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            var productDTOs = _db.Products.Where(p => p.ProductCategory.Category == request.Category);

            var productsToReturn = new List<ProductDTO>();
            foreach (var dto in productDTOs)
            {
                var product = new ProductDTO(dto.SKU, dto.Description, dto.Price);
                productsToReturn.Add(product);
            }

            var result = new ProductsResult
            {
                Products = productsToReturn
            };

            return result;
        }

        private readonly ECommerceContext _db;

    }
}
