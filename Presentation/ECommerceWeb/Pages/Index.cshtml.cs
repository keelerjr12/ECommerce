using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ECommerceApplication.CartService;
using ECommerceWeb.Pages;
using MediatR;

namespace ECommerceWeb
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> Products { get; private set; } = new List<ProductViewModel>();

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var productResult = await _mediator.Send(new TopSellingProductsQuery
            {
                NumberOfProducts = 12
            });

            Products = productResult.Products;
        }

        public IActionResult OnPost(string sku)
        {
            //_cartService.AddProductToCart(1, sku, 1);

            return Redirect("Cart");
        }

        private readonly IMediator _mediator;
    }
}
