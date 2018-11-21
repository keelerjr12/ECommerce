namespace ECommerceDomain.Inventory
{
    public class Product
    {
        public string SKU { get; }

        public string Description { get; set; }

        public string Category { get; set; }

        public decimal UnitCost { get; set; }

        public Product(string sku, string description, string category, decimal unitCost)
        {
            SKU = sku;
            Description = description;
            Category = category;
            UnitCost = unitCost;
        }
    }
}
