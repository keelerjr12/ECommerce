namespace ECommerceApplication.Product
{
    public class ProductDTO
    {
        public string SKU { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string ImageFileName { get; }

        public ProductDTO(string sku,string name, string description, decimal price, string imageFileName)
        {
            Name = name;
            SKU = sku;
            Description = description;
            Price = price;
            ImageFileName = imageFileName;
        }
    }
}
