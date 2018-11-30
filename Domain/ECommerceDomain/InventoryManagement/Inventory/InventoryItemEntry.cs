using System;

namespace ECommerceDomain.InventoryManagement.Inventory
{
    public class InventoryItemEntry
    {
        public DateTime DateOccured { get; }

        public string Type { get; }

        public int Quantity { get; }

        public InventoryItemEntry(DateTime dateOccurred, string type, int quantity)
        {
            DateOccured = dateOccurred;
            Type = type;
            Quantity = quantity;
        }
    }
}
