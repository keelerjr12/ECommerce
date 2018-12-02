using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Cart
{
    public class CartRepository : ICartRepository
    {
        public CartRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Sales.Cart.Cart FindById(int id)
        {
            var cartDTO = _eCommerceContext.Cart.Where(c => c.Id == id).Include(c => c.CartItems).ThenInclude(p => p.Product).FirstOrDefault();

            var cart = new ECommerceDomain.Sales.Cart.Cart(cartDTO.Id);

            foreach (var item in cartDTO.CartItems)
            {
                var product = item.Product;
                cart.Add(new ECommerceDomain.Sales.Product.Product(product.Id, product.SKU, product.Manufacturer, product.Description, product.Price, product.Category),
                    Quantity.Is(item.Quantity));
            }

            return cart;
        }

        //TODO: Change DTOs to domain models prior to EXCEPT()
        //TODO: Prevents null references
        public void Update(ECommerceDomain.Sales.Cart.Cart cart)
        {
            var cartDTO = _eCommerceContext.Cart.Include(c => c.CartItems).First(c => c.Id == 1);
            var storedCartItems = ToCartItemList(cartDTO.CartItems);

            var cartItemsToAdd = cart.Items.Except(storedCartItems, new CartItemComparer());
            var cartItemsToDelete = storedCartItems.Except(cart.Items, new CartItemComparer()).ToList();

            
            foreach (var itemToDelete in cartItemsToDelete)
            {
                cartDTO.CartItems.RemoveAll(item => item.Product.SKU == itemToDelete.SKU);
            }

            foreach (var cartItem in cartItemsToAdd)
            {
                var foundDTO = cartDTO.CartItems.Find(item => item.Product.SKU == cartItem.SKU);

                if (foundDTO == null)
                {
                    var cartItemDTO = new CartItemDTO
                    {
                        CartId = cartDTO.Id,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity.Value
                    };

                    cartDTO.CartItems.Add(cartItemDTO);
                }
                else
                {
                    foundDTO.Quantity = cartItem.Quantity.Value;
                }
            }
        }

        private IList<Item> ToCartItemList(IReadOnlyList<CartItemDTO> dtoItems)
        {
            var cartItems = new List<Item>();

            foreach (var itemDTO in dtoItems)
            {
                var productDTO = itemDTO.Product;
                var product = new ECommerceDomain.Sales.Product.Product(productDTO.Id, productDTO.SKU, productDTO.Manufacturer,
                    productDTO.Description, productDTO.Price, productDTO.Category);

                var cartItem = new Item(product, Quantity.Is(itemDTO.Quantity));

                cartItems.Add(cartItem);
            }

            return cartItems;
        }

        private ECommerceContext _eCommerceContext;
    }

    internal class CartItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.SKU == y.SKU;
        }

        public int GetHashCode(Item obj)
        {
            return obj.SKU.GetHashCode();
        }
    }
}
