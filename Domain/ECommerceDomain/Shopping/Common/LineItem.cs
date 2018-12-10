namespace ECommerceDomain.Shopping.Common
{
    public class LineItem
    {
        public string SKU { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public LineItem(string sku, int quantity, decimal price)
        {
            SKU = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}