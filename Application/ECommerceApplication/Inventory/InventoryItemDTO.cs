namespace ECommerceApplication.Inventory
{
    public class InventoryItemDTO
    {
        public string SKU { get; }
        public string Description { get; }
        public string Category { get; }
        public decimal UnitCost { get; }
        public int Stock { get; }

        public InventoryItemDTO(string sku, string description, string category, decimal unitCost, int stock)
        {
            SKU = sku;
            Description = description;
            Category = category;
            UnitCost = unitCost;
            Stock = stock;
        }
    }
}
