namespace ECommerceDomain.Inventory
{
    public class InventoryItem
    {
        public int Id { get; }

        public InventoryProduct Product { get; private set; }

        public int Stock { get; private set; }

        public decimal UnitCost { get; }

        public InventoryItem(int id, InventoryProduct product, int stock, decimal unitCost)
        {
            Id = id;
            Product = product;
            Stock = stock;
            UnitCost = unitCost;
        }

        internal void UpdateDetails(InventoryProduct product)
        {
            Product = product;
        }

        internal void DecreaseStock(int quantity)
        {
            Stock -= quantity;
        }
    }
}
