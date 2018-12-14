using System.Threading.Tasks;
using ECommerceApplication.Product.Commands;
using ECommerceWeb.Areas.Account.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Catalog
{
    public class AddProductModel : PageModel
    {

        [BindProperty]
        public NewProductViewModel ProductView { get; set; }

        public AddProductModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _mediator.Send(new AddProductToCatalogCommand.Request
            {
                SKU = ProductView.SKU,
                CategoryId = 1,
                Description = ProductView.Description,
                ImageFileName = "14k-gold-sterling-silver-cubic-zirconia-entwined-ring.jpg",
                Manufacturer = ProductView.Manufacturer,
                Name = ProductView.Name,
                Price = ProductView.Price
            });

            return RedirectToPage("/Index");
        }

        private readonly IMediator _mediator;
    }
}