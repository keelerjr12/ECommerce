namespace ECommerceApplication.Ordering.Order
{
    public class OrderLineDTO
    {
        public string SKU { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}