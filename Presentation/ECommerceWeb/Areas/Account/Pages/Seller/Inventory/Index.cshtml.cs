using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.Inventory;
using ECommerceApplication.Inventory.Commands;
using ECommerceApplication.Inventory.Queries;
using ECommerceWeb.Areas.Account.Models.Inventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Inventory
{
    [Area("Admin/Inventory")]
    public class InventoryModel : PageModel
    {
        [BindProperty]
        public ItemPurchase ItemPurchase { get; set; }

        [BindProperty]
        public int Stock { get; set; }

        [BindProperty]
        public decimal InventoryValue { get; set; }

        public List<InventoryItemViewModel> ItemViewModels { get; } = new List<InventoryItemViewModel>();

        public InventoryModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var inventory = _mediator.Send(new AllInventoryItemsQuery.Request()).Result;

            Stock = inventory.Stock;
            InventoryValue = inventory.Value;

            foreach (var item in inventory.Items)
            {
                var iiVM = Mapper.Map<InventoryItemDTO, InventoryItemViewModel>(item);

                ItemViewModels.Add(iiVM);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage();
            }

            _mediator.Send(new PurchaseStockCommand.Request(ItemPurchase.SKU, ItemPurchase.Quantity));

            return RedirectToPage("Index");

        }

        private readonly IMediator _mediator;
    }
}