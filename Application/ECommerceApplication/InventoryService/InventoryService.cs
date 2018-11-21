using System.Linq;
using ECommerceData;
using ECommerceDomain.Inventory;

namespace ECommerceApplication.InventoryService
{
    public class InventoryService
    {
        public InventoryService(UnitOfWork uow, IInventoryRepository inventoryRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
        }

        public Inventory GetInventory()
        {
            return _inventoryRepo.FindById(1);
        }

        public InventoryItem GetInventoryItem(string sku)
        {
            var inventory = _inventoryRepo.FindById(1);
            var item = inventory.Items.First(i => i.SKU == sku);

            return item;
        }

        public void TrackProduct(string sku, string description, string category, decimal retailPrice)
        {
            var inventory = _inventoryRepo.FindById(1);
            inventory.TrackProduct(new Product(sku, description, category, retailPrice));

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void PurchaseStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);
            var inventoryItem = GetInventoryItem(sku);
            var product = new Product(inventoryItem.SKU, inventoryItem.Description, inventoryItem.Category,
                inventoryItem.UnitCost);
            inventory.Purchase(product, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void SellStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);
            var inventoryItem = GetInventoryItem(sku);
            var product = new Product(inventoryItem.SKU, inventoryItem.Description, inventoryItem.Category,
                inventoryItem.UnitCost);

            inventory.Sell(product, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void ChangeInventoryItemDetails(string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(1);
            var inventoryItem = GetInventoryItem(sku);

            var product = new Product(inventoryItem.SKU, description, category, unitCost);

            inventory.UpdateProduct(product);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
    }
}
