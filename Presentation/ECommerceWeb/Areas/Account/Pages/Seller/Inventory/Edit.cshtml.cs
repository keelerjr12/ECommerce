using ECommerceApplication.Inventory;
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

        public EditModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet(string id)
        {
            var sku = id;

            var product = _inventoryService.GetProductBySKU(sku);
            var inventoryItem = _inventoryService.GetInventoryItem(id);

            SKU = product.SKU;
            Description = product.Description;
            Category = product.Category;
            UnitCost = inventoryItem.UnitCost;
        }

        public void OnPost()
        {
            _inventoryService.ChangeProductDetails(SKU, Description, Category);
            _inventoryService.ChangeUnitCost(SKU, UnitCost);
        }

        private readonly InventoryService _inventoryService;
    }
}