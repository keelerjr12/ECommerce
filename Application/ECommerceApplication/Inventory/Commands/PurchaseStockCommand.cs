using System;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Inventory.Inventory;
using MediatR;

namespace ECommerceApplication.Inventory.Commands
{
    public class PurchaseStockCommand
    {
        public class Request : IRequest
        {
            public string SKU { get; }
            public int Quantity { get; }

            public Request(string sku, int quantity)
            {
                SKU = sku;
                Quantity = quantity;
            }
        }

        public class Handler : IRequestHandler<Request>
        {

            public Handler(UnitOfWork uow, IInventoryRepository inventoryRepo)
            {
                _uow = uow;
                _inventoryRepo = inventoryRepo;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var inventory = _inventoryRepo.Get();

                inventory.Purchase(request.SKU, request.Quantity, DateTime.Now);

                _inventoryRepo.Save(inventory);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IInventoryRepository _inventoryRepo;
        }
    }
}
