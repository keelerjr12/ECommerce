namespace ECommerceWeb.Areas.Admin.Models.Orders
{
    public class OrderLineVM
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
