using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;

namespace ECommerceData
{
    public class CartRepository : ICartRepository
    {
        public CartRepository()
        {
            _cart = new Cart();
            _cart.Add(new Product("232097127182", "Sony", "Sony 85\" HDTV", 1999.99m), Quantity.Is(5));
            _cart.Add(new Product("230952093785", "Samsung", "Samsung 65\" 4K UHDTV", 1599.95m), Quantity.Is(3));
        }

        public Cart FindById(string id)
        {
            return _cart;
        }

        private Cart _cart;
    }
}
