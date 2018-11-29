using ECommerceDomain.InventoryManagement.Inventory;

namespace ECommerceWeb.Areas.Inventory
{
    public class InventoryItemViewModel
    {
        public string SKU { get; }
        public int Stock { get; }
        public decimal UnitCost { get; }

        public InventoryItemViewModel(InventoryItem item)
        {
            SKU = item.SKU;
            Stock = item.Stock;
            UnitCost = item.UnitCost;
        }
    }
}
