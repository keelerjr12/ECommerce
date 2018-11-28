using System;

namespace ECommerceDomain.Inventory
{
    public class InventoryItemEntry
    {
        public Guid Id { get; }

        public string SKU { get; }

        public DateTime DateOccured { get; }

        public string Type { get; }

        public int Quantity { get; }

        public InventoryItemEntry(Guid Id, string sku, DateTime dateOccurred, string type, int quantity)
        {
            SKU = sku;
            DateOccured = dateOccurred;
            Type = type;
            Quantity = quantity;
        }
    }
}
