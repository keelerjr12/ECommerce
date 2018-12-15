using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Inventory.Inventory;
using ECommerceDomain.Ordering.Events;
using MediatR;

namespace ECommerceApplication.Inventory
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        public OrderCreatedEventHandler(UnitOfWork uow, IInventoryRepository inventoryRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
        }

        public async Task Handle(OrderCreatedEvent order, CancellationToken cancellationToken)
        {
            var inventory = _inventoryRepo.Get();

            inventory.Sell(order.SKU, order.Quantity, order.Created);

            _inventoryRepo.Save(inventory);

            _uow.Save();
        }

        private readonly IInventoryRepository _inventoryRepo;
        private readonly UnitOfWork _uow;
    }
}
