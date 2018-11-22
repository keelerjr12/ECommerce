using ECommerceApplication.InventoryService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Inventory.Pages
{
    public class AddModel : PageModel
    {
        public AddModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnGet()
        {
        }

        public void OnPost(string sku, string description, string category, int quantity, decimal unitCost)
        {
            _inventoryService.PurchaseStock(sku, quantity);
        }

        private readonly InventoryService _inventoryService;

    }
}