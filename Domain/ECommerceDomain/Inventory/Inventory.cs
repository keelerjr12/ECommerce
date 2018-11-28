using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Inventory
{
    public class Inventory
    {
        public int Id { get; }

        public IReadOnlyList<InventoryItem> Items => _items.ToList();

        public int ItemCount
        {
            get { return _items.Sum(i => i.Stock); }
        }

        public decimal Value
        {
            get { return _items.Sum(i => i.Stock * i.UnitCost); }
        }

        public Inventory(int id, List<InventoryItem> items)
        {
            Id = id;
            _items = items.ToList();
        }

        public void TrackProduct(string sku, string description, string category, decimal unitCost)
        {
            var item = new InventoryItem(Id, sku, description, category, unitCost, new List<InventoryItemEntry>());

            _items.Add(item);
        }

        public void UntrackProduct(string sku)
        {
            CheckProductExists(sku);

            _items.RemoveAll(i => i.SKU == sku);
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

        public void UpdateDescription(string sku, string description)
        {
            CheckProductExists(sku);

            var item = FindItemByProduct(sku);
            item.UpdateDescription(description);
        }

        private void CheckProductExists(string sku)
        {
            if (!_items.Exists(item => item.SKU == sku))
            {
                throw new Exception("Product does not exist");
            }
        }

        private InventoryItem FindItemByProduct(string sku)
        {
            return _items.First(i => i.SKU == sku);
        }

        private readonly List<InventoryItem> _items;
    }
}
