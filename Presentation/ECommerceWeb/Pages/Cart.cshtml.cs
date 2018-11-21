using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApplication.CartService;

namespace ECommerceWeb.Pages
{
    public class CartModel : PageModel
    {
        public int ItemCount { get; private set; }

        public decimal Subtotal { get; private set; }

        public List<CartItemModel> Items { get; } = new List<CartItemModel>();

        public CartModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public void OnGet()
        {
            var cart = _cartService.GetCart();

            ItemCount = cart.ItemCount.Value;
            Subtotal = cart.Subtotal;

            var sortedItems = cart.Items.OrderBy(item => item.Description);

            foreach (var item in sortedItems)
            {
                Items.Add(new CartItemModel(item));
            }
        }

        public IActionResult OnPost(string sku)
        {
            _cartService.RemoveProductFromCart(1, sku, 1);

            return RedirectToPage("Cart");
        }

        private readonly CartService _cartService;
    }
}