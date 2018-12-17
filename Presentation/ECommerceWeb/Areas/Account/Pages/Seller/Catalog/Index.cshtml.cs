using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Shopping.Product.Commands;
using ECommerceApplication.Shopping.Product.Queries;
using ECommerceWeb.Areas.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Catalog
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
                    SKU = product.SKU,
                    Name = product.Name,
                    Description = product.Description,
                    ImageFileName = product.ImageFileName,
                    Status = product.Status,
                    Price = product.Price
                });
            }
        }

        public async Task<IActionResult> OnPostActivateAsync(string sku)
        {
            await _mediator.Send(new ActivateProductInCatalogCommand.Request
            {
                SKU = sku
            });

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeactivateAsync(string sku)
        {
            await _mediator.Send(new DeactivateProductFromCatalogCommand.Request(sku));

            return RedirectToPage();
        }

        private readonly IMediator _mediator;
    }
}