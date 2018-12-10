using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Product.Queries
{
    public class ProductsQuery
    {
        public class Request : IRequest<Result>
        {
            public string Category { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var productDTOs = _db.Products.Where(p => p.ProductCategory.Category == request.Category);

                var productsToReturn = new List<ProductDTO>();
                foreach (var dto in productDTOs)
                {
                    var product = new ProductDTO(dto.SKU, dto.Description, dto.Price);
                    productsToReturn.Add(product);
                }

                var result = new ProductsQuery.Result
                {
                    Products = productsToReturn
                };

                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public List<ProductDTO> Products { get; set; }
        }
    }
}
