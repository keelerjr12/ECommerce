using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;

namespace ECommerceApplication.CartService
{
    public class CartService : ICartService
    {
        public CartService(ICartRepository cartRepo, IProductRepository productRepo)
        {
            _cartRepo = cartRepo;
           _productRepo = productRepo;
        }

        public void AddProductToCart(string cartId, string sku, int quantity)
        {
            var cart = _cartRepo.FindById(cartId);
            var product = _productRepo.FindBySku(sku);

            cart.Add(product, Quantity.Is(quantity));
        }

        public void RemoveProductFromCart(string cartId, string sku, int quantity)
        {
            var cart = _cartRepo.FindById(cartId);
            var product = _productRepo.FindBySku(sku);

            cart.Remove(product, Quantity.Is(quantity));
        }

        public Cart GetCart()
        {
            return _cartRepo.FindById("1");
        }

        private ICartRepository _cartRepo;
        private IProductRepository _productRepo;
    }
}
