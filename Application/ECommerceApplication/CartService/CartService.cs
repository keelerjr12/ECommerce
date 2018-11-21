using ECommerceData;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;

namespace ECommerceApplication.CartService
{
    public class CartService
    {
        public CartService(UnitOfWork uow, ICartRepository cartRepo, IProductRepository productRepo)
        {
            _uow = uow;
            _cartRepo = cartRepo;
           _productRepo = productRepo;
        }

        public void AddProductToCart(int cartId, string sku, int quantity)
        {
            var cart = _cartRepo.FindById(cartId);
            var product = _productRepo.FindBySku(sku);

            cart.Add(product, Quantity.Is(quantity));
            _cartRepo.Update(cart);

            _uow.Save();
        }

        public void RemoveProductFromCart(int cartId, string sku, int quantity)
        {
            var cart = _cartRepo.FindById(cartId);
            var product = _productRepo.FindBySku(sku);

            cart.Remove(product, Quantity.Is(quantity));
            _cartRepo.Update(cart);

            _uow.Save();
        }

        public Cart GetCart()
        {
            return _cartRepo.FindById(1);
        }

        private UnitOfWork _uow;
        private ICartRepository _cartRepo;
        private IProductRepository _productRepo;
    }
}
