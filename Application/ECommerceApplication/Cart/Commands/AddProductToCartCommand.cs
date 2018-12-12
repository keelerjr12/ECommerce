using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Shopping.Product;
using ECommerceDomain.Shopping.Cart;
using ECommerceDomain.Shopping.Common;
using MediatR;

namespace ECommerceApplication.Cart.Commands
{
    public class AddProductToCartCommand
    {
        public class Request : IRequest
        {
            public int CustomerId { get; }
            public string SKU { get; }
            public int Quantity { get; }

            public Request(int customerId, string sku, int quantity)
            {
                CustomerId = customerId;
                SKU = sku;
                Quantity = quantity;
            }
        }

        public class Handler : IRequestHandler<Request>
        {
            public Handler(UnitOfWork uow, ICartRepository cartRepo, IProductRepository productRepo)
            {
                _uow = uow;
                _cartRepo = cartRepo;
                _productRepo = productRepo;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var cart = _cartRepo.FindById(request.CustomerId);
                var product = _productRepo.FindBySku(request.SKU);

                cart.Add(product, Quantity.Is(request.Quantity));

                _cartRepo.Update(cart);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly ICartRepository _cartRepo;
            private readonly IProductRepository _productRepo;
        }
    }
}
