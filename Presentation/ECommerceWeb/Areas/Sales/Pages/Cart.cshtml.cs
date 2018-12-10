using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApplication.CartService;
using ECommerceWeb.Areas.Sales.Models;

namespace ECommerceWeb.Areas.Sales.Pages
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

        public IActionResult OnPostAdd(string sku)
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _cartService.AddProductToCart(customerId, sku, 1);

            return RedirectToPage();
        }

        public IActionResult OnPostRemove(string sku)
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _cartService.RemoveProductFromCart(customerId, sku, 1);

            return RedirectToPage();
        }

        private readonly CartService _cartService;
    }
}