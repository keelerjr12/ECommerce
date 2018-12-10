using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.CartService;
using ECommerceApplication.Product;
using ECommerceApplication.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> ProductViews { get; private set; }

        public IndexModel(IMediator mediator, CartService cartService)
        {
            _mediator = mediator;
            _cartService = cartService;

            var productResult = _mediator.Send(new TopSellingProductsQuery.Request
            {
                NumberOfProducts = 12
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Result.Products);
        }

        public async Task<IActionResult> OnPostAsync(string sku)
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            var customerId = int.Parse(customerIdStr);

            _cartService.AddProductToCart(customerId, sku, 1);

            return Page();
        }

        private readonly IMediator _mediator;
        private readonly CartService _cartService;
    }
}