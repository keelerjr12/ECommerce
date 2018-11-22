using ECommerceDomain.Inventory;

namespace ECommerceWeb.Areas.Inventory
{
    public class InventoryItemViewModel
    {
        public string SKU { get; }
        public string Description { get; }
        public string Category { get; }
        public int Stock { get; }
        public decimal UnitCost { get; }

        public InventoryItemViewModel(InventoryItem item)
        {
            SKU = item.Product.SKU;
            Description = item.Product.Description;
            Category = item.Product.Category;
            Stock = item.Stock;
            UnitCost = item.UnitCost;
        }
    }
}
