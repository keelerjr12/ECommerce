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
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var productDTOs = _db.Products.AsQueryable();

                if (!string.IsNullOrEmpty(request.Category))
                {
                    productDTOs = productDTOs.Where(p => p.ProductCategory.Category == request.Category);
                }

                if (!string.IsNullOrEmpty(request.Description))
                {
                    var normalizedDescription = Normalize(request.Description);
                    var descriptionSplitByToken = normalizedDescription.Split();
                    productDTOs = productDTOs.Where(p => descriptionSplitByToken.Intersect(Normalize(p.Description).Split()).Any());
                }

                var productsToReturn = new List<ProductDTO>();
                foreach (var dto in productDTOs)
                {
                    var product = new ProductDTO(dto.SKU, dto.Description, dto.Price, dto.ImageFileName);
                    productsToReturn.Add(product);
                }

                var result = new ProductsQuery.Result
                {
                    Products = productsToReturn
                };

                return result;
            }

            private string Normalize(string input)
            {
                return new string(input.ToLowerInvariant().Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)).ToArray());
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public List<ProductDTO> Products { get; set; }
        }
    }
}
