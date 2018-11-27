namespace ECommerceDomain.Product
{
    public class Product
    {
        public string SKU { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string Category { get;  }

        public Product(string sku, string description, decimal price, string category)
        {
            Category = category;
            SKU = sku;
            Description = description;
            Price = price;
        }
    }
}
