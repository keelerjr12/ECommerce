namespace ECommerceDomain.Inventory
{
    public class InventoryProduct
    {
        public string SKU { get; }
        
        public string Description { get; }

        public string Category { get; }

        public InventoryProduct(string sku, string description, string category)
        {
            SKU = sku;
            Description = description;
            Category = category;
        }
    }
}
