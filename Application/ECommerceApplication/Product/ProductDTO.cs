namespace ECommerceApplication.Product
{
    public class ProductDTO
    {
        public string SKU { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string ImageFileName { get; }

        public ProductDTO(string sku, string description, decimal price, string imageFileName)
        {
            SKU = sku;
            Description = description;
            Price = price;
            ImageFileName = imageFileName;
        }
    }
}
