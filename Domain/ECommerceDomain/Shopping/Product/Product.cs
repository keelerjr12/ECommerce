using ECommerceDomain.Common;

namespace ECommerceDomain.Shopping.Product
{ 
    public class Product : AggregateRoot
    {
        public int Id { get; }

        public string SKU { get; }

        public string Name { get; }

        public string Manufacturer { get; }

        public string Description { get; }

        public decimal Price { get; }

        public int CategoryId { get; }

        public string ImageFileName { get; }
        
        public Product(int id, string sku, string name, string manufacturer, string description,
            decimal price, int categoryId, string imageFileName)
        {
            Id = id;
            SKU = sku;
            Name = name;
            Manufacturer = manufacturer;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            ImageFileName = imageFileName;
        }
    }
}
