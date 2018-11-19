using ECommerceDomain.Sales.Cart;

namespace ECommerceApplication.CartService
{
    public interface ICartService
    {
        void AddProductToCart(int cartId, string sku, int quantity);
        void RemoveProductFromCart(int cartId, string sku, int quantity);

        Cart GetCart();
    }
}
