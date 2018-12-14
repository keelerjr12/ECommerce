using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Shopping.Product.Commands;
using ECommerceApplication.Shopping.ProductCategory.Queries;
using ECommerceWeb.Areas.Account.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Catalog
{
    public class AddProductModel : PageModel
    {

        [BindProperty]
        public NewProductViewModel ProductView { get; set; }

        public IList<SelectListItem> ProductCategories { get; } = new List<SelectListItem>();

        public AddProductModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var categoriesDTOs = _mediator.Send(new AllProductCategoriesQuery.Request()).Result.ProductCategories;

            // TODO: fix view/viewmodel
            foreach (var category in categoriesDTOs)
            {
                ProductCategories.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
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
                CategoryId = ProductView.CategoryId,
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