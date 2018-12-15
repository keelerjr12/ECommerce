using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Areas.Account.Models.Inventory
{
    public class ItemPurchase
    {
        public string SKU { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
