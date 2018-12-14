using ECommerceDomain.InventoryManagement.Inventory;

namespace ECommerceWeb.Areas.Admin.Inventory.Models
{
    public class InventoryItemViewModel
    {
        public string SKU { get; }

        public string Description { get; }

        public string Category { get; }

        public int Stock { get; }

        public decimal UnitCost { get; }

        public InventoryItemViewModel(ECommerceDomain.InventoryManagement.Product.Product product, InventoryItem item)
        {
            SKU = item.SKU;
            Description = product.Description;
            Category = product.Category;
            Stock = item.Stock;
            UnitCost = item.UnitCost;
        }
    }
}
