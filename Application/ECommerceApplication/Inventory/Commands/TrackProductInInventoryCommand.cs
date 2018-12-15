using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Inventory.Inventory;
using MediatR;

namespace ECommerceApplication.Inventory.Commands
{
    public class TrackProductInInventoryCommand
    {
        public class Request : IRequest
        {
            public string SKU { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public decimal UnitCost { get; set; }
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

                inventory.TrackProduct(request.SKU, request.Description, request.Category, request.UnitCost);

                _inventoryRepo.Save(inventory);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly IInventoryRepository _inventoryRepo;
        }
    }
}
