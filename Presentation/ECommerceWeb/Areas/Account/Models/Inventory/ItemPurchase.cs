using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Areas.Admin.Inventory.Models
{
    public class ItemPurchase
    {
        public string SKU { get; set; }

        [Required]
        public int? Quantity { get; set; }
    }
}
