using ECommerceApplication.Inventory;
using ECommerceApplication.Inventory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Inventory
{
    public class AddModel : PageModel
    {
        public AddModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void OnPost(string sku, string description, string category, decimal unitCost)
        {
            _mediator.Send(new TrackProductInInventoryCommand.Request
            {
                SKU = sku,
                Description =  description,
                Category = category,
                UnitCost = unitCost
            });
        }

        private readonly IMediator _mediator;

    }
}