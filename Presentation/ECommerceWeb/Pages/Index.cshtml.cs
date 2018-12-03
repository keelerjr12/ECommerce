using System.Collections.Generic;
using System.Linq;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApplication.CartService;
using ECommerceDomain.Sales.Product;
using ECommerceWeb.Areas.Product.Pages;

namespace ECommerceWeb
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products { get; } = new List<ProductViewModel>();

        public IndexModel(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public void OnGet()
        {
            var products = _productService.GetTopSellingProducts(12);

            foreach (var prod in products)
            {
                var productVM = new ProductViewModel
                {
                    SKU = prod.SKU,
                    Description = prod.Description,
                    Price = prod.Price,
                    CategoryId = prod.CategoryId
                };

                Products.Add(productVM);
            }
        }

        public IActionResult OnPost(string sku)
        {
            _cartService.AddProductToCart(1, sku, 1);

            return Redirect("Cart");
        }

        private ProductService _productService;
        private CartService _cartService;
    }
}
