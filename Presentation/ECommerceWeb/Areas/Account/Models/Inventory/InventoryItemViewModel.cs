namespace ECommerceWeb.Areas.Account.Models.Inventory
{
    public class InventoryItemViewModel
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal UnitCost { get; set; }
        public int Stock { get; set; }
    }
}
