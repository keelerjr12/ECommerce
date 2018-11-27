using ECommerceApplication.InventoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Inventory.Pages
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

        public EditModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet(string sku)
        {
            var inventoryItem = _inventoryService.GetInventoryItem(sku);
            SKU = inventoryItem.SKU;
            Description = inventoryItem.Description;
            Category = inventoryItem.Category;
            UnitCost = inventoryItem.UnitCost;
        }

        public void OnPost()
        {
            _inventoryService.ChangeInventoryItemDetails(SKU, Description, Category, UnitCost);
        }

        private readonly InventoryService _inventoryService;
    }
}