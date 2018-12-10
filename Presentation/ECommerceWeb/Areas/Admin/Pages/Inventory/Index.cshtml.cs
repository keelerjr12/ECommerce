using System.Collections.Generic;
using ECommerceApplication.Inventory;
using ECommerceWeb.Areas.Admin.Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Admin.Pages.Inventory
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

        public InventoryModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;

            var inventory = _inventoryService.GetInventory();

            Stock = inventory.ItemCount;
            InventoryValue = inventory.Value;

            // TODO: Refactor to use query handler w/automapping
            foreach (var item in inventory.Items)
            {
                var product = _inventoryService.GetProductBySKU(item.SKU);

                ItemViewModels.Add(new InventoryItemViewModel(product, item));
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _inventoryService.PurchaseStock(ItemPurchase.SKU, ItemPurchase.Quantity.Value);

            return RedirectToPage("Index");

        }

        private readonly InventoryService _inventoryService;
    }
}