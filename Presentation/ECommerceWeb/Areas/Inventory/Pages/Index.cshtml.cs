using System.Collections.Generic;
using ECommerceApplication.InventoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Inventory.Pages
{
    public class InventoryModel : PageModel
    {
        public int Stock { get; private set; }

        public decimal InventoryValue { get; private set; }

        public List<InventoryItemViewModel> ItemViewModels { get; } = new List<InventoryItemViewModel>();

        public InventoryModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
            var inventory = _inventoryService.GetInventory();

            Stock = inventory.ItemCount;

            InventoryValue = inventory.Value;

            foreach (var item in inventory.Items)
            {
                ItemViewModels.Add(new InventoryItemViewModel(item));
            }
        }

        public IActionResult OnPost(string sku, int quantity)
        {
            _inventoryService.PurchaseStock(sku, quantity);

            return RedirectToPage("/Index");
        }

        private readonly InventoryService _inventoryService;
    }
}