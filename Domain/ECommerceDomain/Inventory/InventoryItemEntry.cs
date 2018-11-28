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

        public InventoryItemEntry(Guid id, string sku, DateTime dateOccurred, string type, int quantity)
        {
            Id = id;
            SKU = sku;
            DateOccured = dateOccurred;
            Type = type;
            Quantity = quantity;
        }
    }
}
