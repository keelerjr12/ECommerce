namespace ECommerceDomain.Inventory
{
    public class Product
    {
        public string SKU { get; }

        public string Description { get; }

        public string Category { get; }

        public decimal UnitCost { get; }

        public Product(string sku, string description, string category, decimal unitCost)
        {
            SKU = sku;
            Description = description;
            Category = category;
            UnitCost = unitCost;
        }
    }
}
