namespace ECommerceDomain.Inventory
{
    public class InventoryItem
    {
        public string SKU { get; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public int Stock { get; private set; }
        public decimal UnitCost { get; private set; }

        public InventoryItem(Product product)
        {
            SKU = product.SKU;
            Description = product.Description;
            Category = product.Category;
            UnitCost = product.UnitCost;
        }

        internal void UpdateDetails(Product product)
        {
            Description = product.Description;
            Category = product.Category;
            UnitCost = product.UnitCost;
        }

        internal void IncreaseStock(int quantity)
        {
            Stock += quantity;
        }

        internal void DecreaseStock(int quantity)
        {
            Stock -= quantity;
        }
    }
}
