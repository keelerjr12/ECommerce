namespace ECommerceDomain.Shopping.Product
{ 
    public class Product
    {
        public int Id { get; }

        public string SKU { get; }

        public string Description { get; }

        public decimal Price { get; }

        public int CategoryId { get; }

        public Product(int id, string sku, string manufacturer, string description, decimal price, int categoryId )
        {
            Id = id;
            SKU = sku;
            _manufacturer = manufacturer;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

        private readonly string _manufacturer;
    }
}
