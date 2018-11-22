using System.Collections.Generic;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Product.Pages
{
    public class ProductModel : PageModel
    {

        public List<ECommerceDomain.Product.Product> Products { get; private set; }

        public ProductModel(ProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetAllProducts();
        }

        private ProductService _productService;
    }
}