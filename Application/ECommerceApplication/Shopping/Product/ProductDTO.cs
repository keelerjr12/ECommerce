namespace ECommerceApplication.Shopping.Product
{
    public class ProductDTO
    {
        public string SKU { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string ImageFileName { get; }
        public string Status { get; set; }

        public ProductDTO(string sku,string name, string description, decimal price, string imageFileName, string status)
        {
            Name = name;
            SKU = sku;
            Description = description;
            Price = price;
            ImageFileName = imageFileName;
            Status = status;
        }
    }
}
