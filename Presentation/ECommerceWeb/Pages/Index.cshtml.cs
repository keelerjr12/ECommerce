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

        public IndexModel(IProductRepository productRepo, ICartService cartService)
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
                    Price = prod.Price
                };

                Products.Add(productVM);
            }
        }

        public IActionResult OnPost(string sku)
        {
            _cartService.AddProductToCart(1, sku, 1);

            return Redirect("Cart");
        }

        private IProductRepository _productRepo;
        private ICartService _cartService;
    }
}
