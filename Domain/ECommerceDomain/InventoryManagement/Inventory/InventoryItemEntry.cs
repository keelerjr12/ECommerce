using System;

namespace ECommerceDomain.InventoryManagement.Inventory
{
    public class InventoryItemEntry
    {
        public string SKU { get; }

        public DateTime DateOccured { get; }

        public string Type { get; }

        public int Quantity { get; }

        public InventoryItemEntry(string sku, DateTime dateOccurred, string type, int quantity)
        {
            SKU = sku;
            DateOccured = dateOccurred;
            Type = type;
            Quantity = quantity;
        }
    }
}
