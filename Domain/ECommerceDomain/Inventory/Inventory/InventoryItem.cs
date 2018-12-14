using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Inventory.Inventory
{
    public class InventoryItem
    {
        public string SKU { get; }

        public int Stock => StockByDate(DateTime.Today);

        public IReadOnlyList<InventoryItemEntry> Entries => _entries.ToList();

        public decimal UnitCost { get; private set; }

        public InventoryItem(Product.Product product, decimal unitCost, List<InventoryItemEntry> entries)
        {
            SKU = product.SKU;
            UnitCost = unitCost;
           _entries = entries;
        }

        public int StockByDate(DateTime date)
        {
            var purchases = _entries.Where(entry => entry.DateOccurred <= date && entry.Type == "PURCHASE").Sum(entry => entry.Quantity);
            var sales = _entries.Where(entry => entry.DateOccurred <= date && entry.Type == "SALE")
               .Sum(entry => entry.Quantity);

            return purchases - sales;
        }

        internal void Purchase(int quantity, DateTime dateOccurred)
        {
            _entries.Add(new InventoryItemEntry(dateOccurred.Date, "PURCHASE", quantity));
        }

        internal void Sell(int quantity, DateTime dateOccurred)
        {
            _entries.Add(new InventoryItemEntry(dateOccurred.Date, "SALE", quantity));
        }

        public void ChangeUnitCost(decimal unitCost)
        {
            UnitCost = unitCost;
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

        private readonly List<InventoryItemEntry> _entries;

    }
}
