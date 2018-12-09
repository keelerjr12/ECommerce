namespace ECommerceDomain.Ordering.Order
{
    public class OrderLine
    {
        public string SKU { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public OrderLine(string sku, int quantity, decimal price)
        {
            SKU = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}
