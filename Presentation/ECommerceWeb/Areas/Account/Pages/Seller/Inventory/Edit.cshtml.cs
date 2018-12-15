using System.Threading.Tasks;
using ECommerceApplication.Inventory.Commands;
using ECommerceApplication.Inventory.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Inventory
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public string SKU { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public string Category { get; set; }

        [BindProperty]
        public decimal UnitCost { get; set; }

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnGet(string sku)
        {

            var inventoryItem = _mediator.Send(new InventoryItemQuery.Request
            {
                SKU = sku
            }).Result;

            SKU = inventoryItem.SKU;
            Description = inventoryItem.Description;
            Category = inventoryItem.Category;
            UnitCost = inventoryItem.UnitCost;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mediator.Send(new ChangeInventoryItemDetails.Request(SKU, Description, Category, UnitCost));

            return RedirectToPage("/Seller/Inventory/Index");
        }

        private readonly IMediator _mediator;
    }
}