using ECommerceDomain.Sales.Cart;

namespace ECommerceWeb.Areas.Sales.Pages
{
    public class CartItemModel
    {
        public decimal Price { get; }

        public string SKU { get;  }

        public int Quantity { get; }

        public string Description { get; }

        public CartItemModel(Item item)
        {
            Description = item.Description;
            SKU = item.SKU;
            Quantity = item.Quantity.Value;
            Price = item.Price;
        }
    }
}
