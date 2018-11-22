using System.Linq;
using ECommerceData;
using ECommerceDomain.Inventory;

namespace ECommerceApplication.InventoryService
{
    public class InventoryService
    {
        public InventoryService(UnitOfWork uow, IInventoryRepository inventoryRepo, IInventoryProductRepository inventoryProductRepo)
        {
            _uow = uow;
            _inventoryRepo = inventoryRepo;
            _inventoryProductRepo = inventoryProductRepo;
        }

        public Inventory GetInventory()
        {
            return _inventoryRepo.FindById(1);
        }

        public InventoryItem GetInventoryItem(int id)
        {
            return GetInventory().Items.First(item => item.Id == id);
        }

        public void PurchaseStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);
            var product = _inventoryProductRepo.GetBySKU(sku);

            inventory.Purchase(product, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void SellStock(string sku, int quantity)
        {
            var inventory = _inventoryRepo.FindById(1);
            var product = _inventoryProductRepo.GetBySKU(sku);

            inventory.Sell(product, quantity);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        public void ChangeInventoryItemDetails(string sku, string description, string category, decimal unitCost)
        {
            var inventory = _inventoryRepo.FindById(1);
            //var inventoryItem = GetInventoryItem(sku);

            var product = new InventoryProduct(sku, description, category);

            inventory.UpdateProduct(product);

            _inventoryRepo.Update(inventory);

            _uow.Save();
        }

        private readonly UnitOfWork _uow;
        private readonly IInventoryRepository _inventoryRepo;
        private IInventoryProductRepository _inventoryProductRepo;
    }
}
