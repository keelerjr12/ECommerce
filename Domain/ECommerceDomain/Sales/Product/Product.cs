namespace ECommerceDomain.Sales.Product
{
    public class Product
    {
        public int Id { get; }

        public string SKU { get; }

        public string Description { get; }

        public decimal Price { get; }

        public string Category { get; }

        public Product(int id, string sku, string manufacturer, string description, decimal price, string category )
        {
            Id = id;
            SKU = sku;
            _manufacturer = manufacturer;
            Description = description;
            Price = price;
            Category = category;
        }

        private readonly string _manufacturer;
    }
}
