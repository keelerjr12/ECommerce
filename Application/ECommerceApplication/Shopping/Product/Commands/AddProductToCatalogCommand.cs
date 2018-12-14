using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Shopping.Product;
using MediatR;

namespace ECommerceApplication.Shopping.Product.Commands
{
    public class AddProductToCatalogCommand
    {
        public class Request : IRequest
        {
            public string SKU { get; set; }
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string ImageFileName { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            public Handler(UnitOfWork uow, IProductRepository productRepo)
            {
                _productRepo = productRepo;
                _uow = uow;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                // TODO: FIX ID Creation
                var product = new ECommerceDomain.Shopping.Product.Product(0, request.SKU, request.Name, request.Manufacturer, request.Description, request.Price, request.CategoryId, request.ImageFileName);
                await _productRepo.SaveAsync(product);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IProductRepository _productRepo;

        }
    }
}
