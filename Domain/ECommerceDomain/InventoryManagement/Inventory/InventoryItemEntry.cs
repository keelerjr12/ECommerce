using System;

namespace ECommerceDomain.InventoryManagement.Inventory
{
    public class InventoryItemEntry
    {
        public DateTime DateOccurred { get; }

        public string Type { get; }

        public int Quantity { get; }

        public InventoryItemEntry(DateTime dateOccurred, string type, int quantity)
        {
            DateOccurred = dateOccurred;
            Type = type;
            Quantity = quantity;
        }
    }
}
