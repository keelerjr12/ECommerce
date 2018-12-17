using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Shopping.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWeb.Areas.Product.Pages
{
    public class ProductModel : PageModel
    {
        public string SKU { get; private set; }
        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string ImageFileName { get; private set; }
        public Dictionary<string, List<SelectListItem>> Options { get; } = new Dictionary<string, List<SelectListItem>>();

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

            foreach (var option in result.Options)
            {
                var values = new List<SelectListItem>();

                foreach (var value in option.Value)
                {
                    values.Add(new SelectListItem(value, value));
                }

                Options.Add(option.Key, values);
            }

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