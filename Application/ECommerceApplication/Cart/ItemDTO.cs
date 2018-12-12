namespace ECommerceApplication.Cart
{
    public class ItemDTO
    {
        public string SKU { get; set; }
        public string Description { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public ItemDTO(string sku, string description, int quantity, decimal price)
        {
            SKU = sku;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
