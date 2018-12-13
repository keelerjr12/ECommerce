using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Shopping.Product;
using MediatR;

namespace ECommerceApplication.Product.Commands
{
    public class RemoveProductFromCatalogCommand
    {
        public class Request : IRequest
        {
            public string SKU { get; }

            public Request(string sku)
            {
                SKU = sku;
            }
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
                await _productRepo.RemoveBySKU(request.SKU);

                _uow.Save();
                
                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IProductRepository _productRepo;

        }
    }
}
