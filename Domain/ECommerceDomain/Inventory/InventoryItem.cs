using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Inventory
{
    public class InventoryItem
    {
        public int InventoryId { get; }

        public string SKU { get; }

        public string Description { get; private set; }

        public string Category { get; private set; }

        public int Stock => StockByDate(DateTime.Today);

        public IReadOnlyList<InventoryItemEntry> Entries => _entries.ToList();

        public decimal UnitCost { get; }

        public InventoryItem(int inventoryId, string sku, string description, string category, decimal unitCost, List<InventoryItemEntry> entries)
        {
            InventoryId = inventoryId;
            SKU = sku;
            Description = description;
            Category = category;
            UnitCost = unitCost;
            _entries = entries;
        }

        public int StockByDate(DateTime date)
        {
            var purchases = _entries.Where(entry => entry.DateOccured <= date && entry.Type == "PURCHASE").Sum(entry => entry.Quantity);
            var sales = _entries.Where(entry => entry.DateOccured <= date && entry.Type == "SALE")
                .Sum(entry => entry.Quantity);

            return purchases - sales;
        }

        internal void UpdateDescription(string description)
        {
            Description = description;
        }

        internal void Purchase(int quantity, DateTime dateOccurred)
        {
            _entries.Add(new InventoryItemEntry(Guid.NewGuid(), SKU, dateOccurred.Date, "PURCHASE", quantity));
        }

        internal void Sell(int quantity, DateTime dateOccurred)
        {
            _entries.Add(new InventoryItemEntry(Guid.NewGuid(), SKU, dateOccurred.Date, "SALE", quantity));
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

        private readonly List<InventoryItemEntry> _entries = new List<InventoryItemEntry>();
    }
}
