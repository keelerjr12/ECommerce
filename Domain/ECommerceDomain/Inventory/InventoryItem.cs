namespace ECommerceDomain.Inventory
{
    public class InventoryItem
    {
        public string SKU { get; }

        public string Description { get; private set; }

        public string Category { get; private set; }

        public int Stock { get; private set; }

        public decimal UnitCost { get; }

        public InventoryItem(string sku, string description, string category,int stock, decimal unitCost)
        {
            SKU = sku;
            Description = description;
            Category = category;
            Stock = stock;
            UnitCost = unitCost;
        }

        internal void UpdateDescription(string description)
        {
            Description = description;
        }

        internal void Purchase(int quantity)
        {
            Stock += quantity;
        }

        internal void Sell(int quantity)
        {
            Stock -= quantity;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !ReferenceEquals(this, obj))
            {
                return false;
            }

            return obj is InventoryItem i && ((SKU == i.SKU) && (SKU == i.SKU));
        }

        public override int GetHashCode()
        {
            return SKU.GetHashCode();
        }
    }
}
