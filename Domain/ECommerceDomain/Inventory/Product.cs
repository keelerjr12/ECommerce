namespace ECommerceDomain.Inventory
{
    public class Product
    {
        private string _sku;
        public int StockCount { get; private set; } = 0;

        public Product(string SKU)
        {
            _sku = SKU;
        }

        public void IncreaseStock(int quantity)
        {
            StockCount += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            StockCount -= quantity;
        }
    }
}
