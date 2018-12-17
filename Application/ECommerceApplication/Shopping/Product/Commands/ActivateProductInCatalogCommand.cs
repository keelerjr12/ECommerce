using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Shopping.Product;
using MediatR;

namespace ECommerceApplication.Shopping.Product.Commands
{
    public class ActivateProductInCatalogCommand
    {
        public class Request : IRequest
        {
            public string SKU { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {

            public Handler(UnitOfWork uow, IProductRepository productRepo)
            {
                _uow = uow;
                _productRepo = productRepo;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var product = _productRepo.GetBySKU(request.SKU);
                product.Activate();

                await _productRepo.SaveAsync(product);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IProductRepository _productRepo;
        }
    }
}

