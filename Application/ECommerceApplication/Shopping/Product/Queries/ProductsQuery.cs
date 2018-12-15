using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Shopping.Product.Queries
{
    public class ProductsQuery
    {
        public class Request : IRequest<Result>
        {
            public int? CategoryId { get; set; }
            public string Status { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var productDTOs = _db.Products.Include(p => p.ProductCategory).AsQueryable();

                if (request.CategoryId != null)
                {
                    productDTOs = productDTOs.Where(p => p.CategoryId == request.CategoryId);
                }

                if (!string.IsNullOrEmpty(request.Status))
                {
                    productDTOs = productDTOs.Where(p => p.Status == request.Status);
                }

                var productsToReturn = new List<ProductDTO>();
                foreach (var productDTO in productDTOs)
                {
                    productsToReturn.Add(new ProductDTO(productDTO.SKU, productDTO.Name, productDTO.Description, productDTO.Price, productDTO.ImageFileName));
                }

                var result = new Result
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
