using System;
using System.Linq;
using ECommerceData;
using ECommerceDomain.InventoryManagement.Inventory;
using ECommerceDomain.InventoryManagement.Product;

namespace ECommerceApplication.Inventory
{
    public class InventoryService
    {
        public InventoryService(UnitOfWork uow, IInventoryRepository inventoryRepo, IProductRepository productRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
            _productRepo = productRepo;
        }

        public ECommerceDomain.InventoryManagement.Inventory.Inventory GetInventory()
        {
            return _inventoryRepo.Get();
        }

        public InventoryItem GetInventoryItem(string sku)
        {
            return GetInventory().Items.First(item => item.SKU == sku);
        }

        public ECommerceDomain.InventoryManagement.Product.Product GetProductBySKU(string sku)
        {
            return _productRepo.GetBySKU(sku);
        }

        public void TrackProduct(string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.Get();

            var product = inventory.TrackProduct(sku, description, category, unitCost);

            _inventoryRepo.Save(inventory);
            _productRepo.Update(product);

            _uow.Save();
        }

        public void PurchaseStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.Get();

            var product = _productRepo.GetBySKU(sku);

            inventory.Purchase(product, quantity, DateTime.Now);

            _inventoryRepo.Save(inventory);

            _uow.Save();
        }

        public void ChangeProductDetails(string sku, string description, string category)
        {
            var product = _productRepo.GetBySKU(sku);

            product.ChangeDescription(description);
            product.ChangeCategory(category);

            _productRepo.Update(product);

            _uow.Save();
        }

        public void ChangeUnitCost(string sku, decimal unitCost)
        {
            var inventory = _inventoryRepo.Get();
            var product = _productRepo.GetBySKU(sku);

            inventory.ChangeProductUnitPrice(product, unitCost);

            _inventoryRepo.Save(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IProductRepository _productRepo;
    }
}
