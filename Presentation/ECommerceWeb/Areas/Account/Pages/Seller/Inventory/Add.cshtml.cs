using ECommerceApplication.Inventory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Inventory
{
    public class AddModel : PageModel
    {
        public AddModel(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void OnPost(string sku, string description, string category, int quantity, decimal unitCost)
        {
            _inventoryService.TrackProduct(sku, description, category, unitCost);
        }

        private readonly InventoryService _inventoryService;

    }
}