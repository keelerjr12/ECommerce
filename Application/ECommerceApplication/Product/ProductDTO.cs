namespace ECommerceApplication.Product
{
    public class ProductDTO
    {
        public string SKU { get; }
        public string Description { get; }
        public decimal Price { get; }

        public ProductDTO(string sku, string description, decimal price)
        {
            SKU = sku;
            Description = description;
            Price = price;
        }
    }
}
