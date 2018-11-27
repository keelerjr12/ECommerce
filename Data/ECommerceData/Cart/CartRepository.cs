using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Common;
using ECommerceDomain.Sales.Product;
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
                cart.Add(new ECommerceDomain.Sales.Product.Product(product.SKU, product.Manufacturer, product.Description, product.Price, product.Category),
                    Quantity.Is(item.Quantity));
            }

            return cart;
        }

        public void Update(ECommerceDomain.Sales.Cart.Cart cart)
        {
            var cartItemDTOs = ToCartItemDTOList(cart.Items);

            var cartDTO = _eCommerceContext.Cart.First(c => c.Id == 1);

            var cartItemsToAdd = cartItemDTOs.Except(cartDTO.CartItems, new DTOComparer());
            var cartItemsToDelete = cartDTO.CartItems.Except(cartItemDTOs, new DTOComparer()).ToList();

            foreach (var itemToDelete in cartItemsToDelete)
            {
                cartDTO.CartItems.RemoveAll(item => item.ProductSKU == itemToDelete.ProductSKU);
            }

            
            foreach (var cartItem in cartItemsToAdd)
            {
                var foundDTO = cartDTO.CartItems.Find(d => d.ProductSKU == cartItem.ProductSKU);

                if (foundDTO == null)
                {
                    var cartItemDTO = new CartItemDTO();
                    cartItemDTO.ProductSKU = cartItem.ProductSKU;
                    cartItemDTO.Quantity = cartItem.Quantity;
                    cartDTO.CartItems.Add(cartItemDTO);
                }
                else
                {
                    foundDTO.Quantity = cartItem.Quantity;
                }
            }
        }

        private IList<CartItemDTO> ToCartItemDTOList(IReadOnlyList<Item> items)
        {
            var dtoList = new List<CartItemDTO>();

            foreach (var item in items)
            {
                var itemDTO = new CartItemDTO
                {
                    ProductSKU = item.SKU,
                    Quantity = item.Quantity.Value
                };

                dtoList.Add(itemDTO);
            }

            return dtoList;
        }

        private ECommerceContext _eCommerceContext;
    }

    internal class DTOComparer : IEqualityComparer<CartItemDTO>
    {
        public bool Equals(CartItemDTO x, CartItemDTO y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.ProductSKU == y.ProductSKU;
        }

        public int GetHashCode(CartItemDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}
