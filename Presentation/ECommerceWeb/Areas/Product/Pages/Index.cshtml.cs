using System.Threading.Tasks;
using ECommerceApplication.Shopping.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Product.Pages
{
    public class ProductModel : PageModel
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageFileName { get; set; }

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
            Name = result.Name;
            Manufacturer = result.Manufacturer;
            Description = result.Description;
            Price = result.Price;
            ImageFileName = result.ImageFileName;
        }

        private readonly IMediator _mediator;
    }
}