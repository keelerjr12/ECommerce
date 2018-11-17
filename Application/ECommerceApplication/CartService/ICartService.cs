using ECommerceDomain.Sales.Cart;

namespace ECommerceApplication.CartService
{
    public interface ICartService
    {
        void AddProductToCart(string cartId, string sku, int quantity);
        void RemoveProductFromCart(string cartId, string sku, int quantity);

        Cart GetCart();
    }
}
