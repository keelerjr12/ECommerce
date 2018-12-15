using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Shopping.Cart;
using ECommerceDomain.Shopping.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Shopping.Cart
{
    public class CartRepository : ICartRepository
    {
        public CartRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Shopping.Cart.Cart FindById(Guid id)
        {
            var cartItemDTOs = _eCommerceContext.CartItems.Where(c => c.CustomerId == id).Include(p => p.Product);

            var cart = new ECommerceDomain.Shopping.Cart.Cart(id);

            foreach (var item in cartItemDTOs)
            {
                var product = item.Product;
                cart.Add(new ECommerceDomain.Shopping.Product.Product(product.Id, product.SKU, product.Name, product.Manufacturer, product.Description, product.Price, product.CategoryId, product.ImageFileName),
                    Quantity.Is(item.Quantity));
            }

            return cart;
        }

        public void Update(ECommerceDomain.Shopping.Cart.Cart cart)
        {
            var cartItemDTOs = _eCommerceContext.CartItems.Where(c => c.CustomerId == cart.Id);
            var storedCartItems = ToCartItemList(cartItemDTOs);

            var cartItemsToAdd = cart.Items.Except(storedCartItems, new CartItemComparer());
            var cartItemsToDelete = storedCartItems.Except(cart.Items, new CartItemComparer()).ToList();

            
            foreach (var itemToDelete in cartItemsToDelete)
            {
                var itemDTO = _eCommerceContext.CartItems.First(item => item.Product.SKU == itemToDelete.SKU);
                _eCommerceContext.CartItems.Remove(itemDTO);
            }

            foreach (var cartItem in cartItemsToAdd)
            {
                var foundDTO = _eCommerceContext.CartItems.Any(item => item.CustomerId == cart.Id && item.Product.SKU == cartItem.SKU);

                if (!foundDTO)
                {
                    var cartItemDTO = new CartItemDTO
                    {
                        CustomerId = cart.Id,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity.Value
                    };

                    _eCommerceContext.CartItems.Add(cartItemDTO);
                }
                else
                {
                    var foundItem = _eCommerceContext.CartItems.First(item => item.Product.SKU == cartItem.SKU);
                    foundItem.Quantity = cartItem.Quantity.Value;
                }
            }

            foreach (var cartItem in cart.Items)
            {
                //TODO: fix this
                var exists = _eCommerceContext.CartItems.Include(c => c.CustomerDTO).Include(p => p.Product).Any(c => c.CustomerId == cart.Id && c.ProductId == cartItem.ProductId);

                if (exists)
                {
                    var cartitemDTO = _eCommerceContext.CartItems.Include(c => c.CustomerDTO).Include(p => p.Product).First(c => c.CustomerId == cart.Id && c.ProductId == cartItem.ProductId);
                    cartitemDTO.Quantity = cartItem.Quantity.Value;
                }
            }
        }

        private IList<Item> ToCartItemList(IQueryable<CartItemDTO> dtoItems)
        {
            var cartItems = new List<Item>();

            foreach (var itemDTO in dtoItems)
            {
                var productDTO = itemDTO.Product;
                var product = new ECommerceDomain.Shopping.Product.Product(productDTO.Id, productDTO.SKU, productDTO.Name, productDTO.Manufacturer,
                    productDTO.Description, productDTO.Price, productDTO.CategoryId, productDTO.ImageFileName);

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
