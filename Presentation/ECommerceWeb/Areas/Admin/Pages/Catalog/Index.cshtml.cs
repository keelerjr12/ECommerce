using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Product.Commands;
using ECommerceApplication.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Admin.Pages.Catalog
{
    public class ProductCatalogModel : PageModel
    {
        [BindProperty]
        public List<ProductViewModel> ProductViews { get; } = new List<ProductViewModel>();

        public ProductCatalogModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new ProductsQuery.Request());

            foreach (var product in result.Products)
            {
                ProductViews.Add(new ProductViewModel
                {
                    Description = product.Description,
                    ImageFileName = product.ImageFileName,
                    Price = product.Price,
                    SKU = product.SKU
                });
            }
        }

        public async Task<IActionResult> OnPostAsync(string sku)
        {
            await _mediator.Send(new RemoveProductFromCatalogCommand.Request(sku));

            return RedirectToPage();
        }

        private readonly IMediator _mediator;
    }
}