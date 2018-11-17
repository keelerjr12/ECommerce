namespace ECommerceDomain.Sales.Product
{
    public class Product
    {
        public string SKU { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Product(string sku, string manufacturer, string description, decimal price)
        {
            SKU = sku;
            _manufacturer = manufacturer;
            Description = description;
            Price = price;
        }

        private readonly string _manufacturer;
    }
}
