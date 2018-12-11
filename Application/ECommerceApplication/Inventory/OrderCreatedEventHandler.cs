using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.InventoryManagement.Inventory;
using ECommerceDomain.InventoryManagement.Product;
using ECommerceDomain.Ordering.Events;
using MediatR;

namespace ECommerceApplication.Inventory
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        public OrderCreatedEventHandler(UnitOfWork uow, IInventoryRepository inventoryRepo, IProductRepository productRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
        }

        public async Task Handle(OrderCreatedEvent order, CancellationToken cancellationToken)
        {
            var inventory = _inventoryRepo.Get();
            var product = _productRepo.GetBySKU(order.SKU);

            inventory.Sell(product, order.Quantity, order.Created);

            _inventoryRepo.Save(inventory);

            _uow.Save();
        }

        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly UnitOfWork _uow;
    }
}
