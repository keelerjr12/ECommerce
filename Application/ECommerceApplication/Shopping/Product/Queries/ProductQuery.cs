using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;

namespace ECommerceApplication.Shopping.Product.Queries
{
    public class ProductQuery
    {
        public class Request : IRequest<Result>
        {
            public string SKU { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var productDTO = _db.Products.First(p => p.SKU == request.SKU);

                var result = new Result
                {
                    SKU = productDTO.SKU,
                    Name = productDTO.Name,
                    Manufacturer = productDTO.Manufacturer,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    ImageFileName = productDTO.ImageFileName
                };

                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public string SKU { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string ImageFileName { get; set; }
        }
    }
}
