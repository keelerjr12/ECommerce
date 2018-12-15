using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Inventory.Inventory
{
    public class Inventory
    {
        public IReadOnlyList<InventoryItem> Items => _items.Values.ToList();

        public int ItemCount
        {
            get { return _items.Values.Sum(i => i.Stock); }
        }

        public decimal Value
        {
            get { return _items.Values.Sum(i => i.Stock * i.UnitCost); }
        }

        public Inventory(IEnumerable<InventoryItem> items)
        {
            foreach (var item in items)
            {
                _items.Add(item.SKU, item);
            }
        }

        public void TrackProduct(string sku, string description, string category, decimal unitCost)
        {
            var item = new InventoryItem(sku, description, category, unitCost, new List<InventoryItemEntry>());

            _items.Add(sku, item);
        }

        public void UntrackProduct(string sku)
        {
            CheckProductExists(sku);

            _items.Remove(sku);
        }

        public void ChangeItemDetails(string sku, string description, string category, decimal unitCost)
        {
            CheckProductExists(sku);

            var item = _items[sku];

            item.ChangeDescription(description);
            item.ChangeCategory(category);
            item.ChangeUnitCost(unitCost);
        }

        public void Purchase(string sku, int quantity, DateTime dateOccurred)
        {
            CheckProductExists(sku);

            var item = FindItemByProduct(sku);
            item.Purchase(quantity, dateOccurred);
        }

        public void Sell(string sku, int quantity, DateTime dateOccurred)
        {
            CheckProductExists(sku);

            var item = FindItemByProduct(sku);
            item.Sell(quantity, dateOccurred);
        }

        private void CheckProductExists(string sku)
        {
            if (!_items.ContainsKey(sku))
            {
                throw new Exception("Product does not exist");
            }
        }

        private InventoryItem FindItemByProduct(string sku)
        {
            return _items[sku];
        }

        private readonly Dictionary<string, InventoryItem> _items = new Dictionary<string, InventoryItem>();

    }
}
