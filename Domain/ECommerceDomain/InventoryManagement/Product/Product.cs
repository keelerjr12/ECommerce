namespace ECommerceDomain.InventoryManagement.Product
{
    public class Product
    {
        public int InventoryId { get; }

        public string SKU { get; }

        public string Description { get; private set; }

        public string Category { get; private set; }

        public Product(string sku, string description, string category)
        {
            SKU = sku;
            Description = description;
            Category = category;
        }

        public void ChangeDescription(string description)
        {
            Description = description;
        }

        public void ChangeCategory(string category)
        {
            Category = category;
        }
    }
}
