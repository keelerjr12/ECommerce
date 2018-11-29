using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApplication.CartService;
using ECommerceDomain.Sales.Product;

namespace ECommerceWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products { get; } = new List<ProductViewModel>();

        public IndexModel(IProductRepository productRepo, CartService cartService)
        {
            _productRepo = productRepo;
            _cartService = cartService;
        }

        public void OnGet()
        {
            var products = _productRepo.GetAllProducts().OrderBy(product => product.Description);

            foreach (var prod in products)
            {
                var productVM = new ProductViewModel
                {
                    SKU = prod.SKU,
                    Description = prod.Description,
                    Price = prod.Price,
                    Category=prod.Category

                };

                Products.Add(productVM);
            }
        }

        public IActionResult OnPost(string sku)
        {
            _cartService.AddProductToCart(1, sku, 1);

            return RedirectToPage("Cart", new { area = "Sales" });
        }

        private IProductRepository _productRepo;
        private CartService _cartService;
    }
}
