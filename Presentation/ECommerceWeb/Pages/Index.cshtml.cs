using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.CartService;
using ECommerceApplication.ProductService;
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


            // TODO: need this???
            var productResult = _mediator.Send(new TopSellingProductsQuery
            {
                NumberOfProducts = 12
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Result.Products);
        }

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new TopSellingProductsQuery
            {
                NumberOfProducts = 12
            });

            ProductViews = Mapper.Map<List<ProductDTO>, List<ProductViewModel>>(productResult.Products);
        }

        public async Task<IActionResult> OnPostAsync(string sku)
        {
            var customerIdStr = User.Claims.First(a => a.Type == ClaimTypes.NameIdentifier).Value;
            //var customerId = int.Parse(customerIdStr);

            _cartService.AddProductToCart(1, sku, 1);

            return Page();
        }

        private readonly IMediator _mediator;
        private readonly CartService _cartService;
    }
}