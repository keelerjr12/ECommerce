using System;
using System.Linq;
using ECommerceData;
using ECommerceDomain.InventoryManagement.Inventory;
using ECommerceDomain.InventoryManagement.Product;

namespace ECommerceApplication.InventoryService
{
    public class InventoryService
    {
        public InventoryService(UnitOfWork uow, IInventoryRepository inventoryRepo, IProductRepository productRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
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
            var inventoryId = 1;

            var inventory = _inventoryRepo.FindById(inventoryId);

            var product = _productRepo.GetBySKU(inventoryId, sku);

            inventory.Purchase(product, quantity, DateTime.Now);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void SellStock(string sku, int quantity)
        {
            var inventoryId = 1;

            var inventory = _inventoryRepo.FindById(inventoryId);

            var product = _productRepo.GetBySKU(inventoryId, sku);

            inventory.Sell(product, quantity, DateTime.Now);
            
            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void ChangeInventoryItemDetails(string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(1);
            var inventoryItem = GetInventoryItem(sku);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
    }
}
