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

        public void OnGet(string id)
        {
            var sku = id;
            var inventoryId = 1;

            var product = _inventoryService.GetProductBySKU(inventoryId, sku);
            var inventoryItem = _inventoryService.GetInventoryItem(id);

            SKU = product.SKU;
            Description = product.Description;
            Category = product.Category;
            UnitCost = inventoryItem.UnitCost;
        }

        public void OnPost()
        {
            const int inventoryId = 1;

            _inventoryService.ChangeProductDetails(inventoryId, SKU, Description, Category);
            _inventoryService.ChangeUnitCost(inventoryId, SKU, UnitCost);
        }

        private readonly InventoryService _inventoryService;
    }
}