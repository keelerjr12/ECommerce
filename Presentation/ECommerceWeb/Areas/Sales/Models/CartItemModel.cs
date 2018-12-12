namespace ECommerceWeb.Areas.Sales.Models
{
    public class CartItemModel
    {
        public decimal Price { get; }

        public string SKU { get;  }

        public int Quantity { get; }

        public string Description { get; }

        public CartItemModel(string sku, string description, int quantity, decimal price)
        {
            Description = description;
            SKU = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}
