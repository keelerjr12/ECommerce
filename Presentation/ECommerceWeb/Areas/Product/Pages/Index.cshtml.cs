using System.Threading.Tasks;
using ECommerceApplication.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Product.Pages
{
    public class ProductModel : PageModel
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync(string sku)
        {
            var result = await _mediator.Send(new ProductQuery.Request
            {
                SKU = sku
            });

            SKU = result.SKU;
            Description = result.Description;
            Price = result.Price;
        }

        private readonly IMediator _mediator;
    }
}