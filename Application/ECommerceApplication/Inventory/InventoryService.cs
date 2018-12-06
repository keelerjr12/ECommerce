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

        public Product GetProductBySKU(int inventoryId, string sku)
        {
            return _productRepo.GetBySKU(inventoryId, sku);
        }

        public void TrackProduct(int inventoryId, string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(inventoryId);

            var product = inventory.TrackProduct(sku, description, category, unitCost);

            _inventoryRepo.Update(inventory);
            _productRepo.Update(product);

            _uow.Save();
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

        public void ChangeProductDetails(int inventoryId, string sku, string description, string category)
        {
            var product = _productRepo.GetBySKU(inventoryId, sku);

            product.ChangeDescription(description);
            product.ChangeCategory(category);

            _productRepo.Update(product);

            _uow.Save();
        }

        public void ChangeUnitCost(int inventoryId, string sku, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(inventoryId);
            var product = _productRepo.GetBySKU(inventoryId, sku);

            inventory.ChangeProductUnitPrice(product, unitCost);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
    }
}
