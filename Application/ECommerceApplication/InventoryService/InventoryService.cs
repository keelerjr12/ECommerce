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
            return GetInventory().Items.First(item => item.SKU == sku);
        }

        public void PurchaseStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);

            inventory.Purchase(sku, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void SellStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);

            inventory.Sell(sku, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void ChangeInventoryItemDetails(string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(1);
            //var inventoryItem = GetInventoryItem(sku);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
    }
}
