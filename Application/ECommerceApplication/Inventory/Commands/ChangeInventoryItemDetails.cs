using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Inventory.Inventory;
using MediatR;

namespace ECommerceApplication.Inventory.Commands
{
    public class ChangeInventoryItemDetails
    {
        public class Request : IRequest
        {

            public string SKU { get; }
            public string Description { get; }
            public string Category { get; }
            public decimal UnitCost { get; }

            public Request(string sku, string description, string category, decimal unitCost)
            {
                SKU = sku;
                Description = description;
                Category = category;
                UnitCost = unitCost;
            }
        }

        public class Handler : IRequestHandler<Request>
        {

            public Handler(UnitOfWork uow, IInventoryRepository inventoryRepo)
            {
                _inventoryRepo = inventoryRepo;
                _uow = uow;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var inventory = _inventoryRepo.Get();

                inventory.ChangeItemDetails(request.SKU, request.Description, request.Category, request.UnitCost);

                _inventoryRepo.Save(inventory);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IInventoryRepository _inventoryRepo;
        }
    }
}
