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

        public void Purchase(InventoryProduct product, int quantity)
        {
            var itemId = GenerateId();
            var item = new InventoryItem(itemId, product, quantity, 10m);

            _items.Add(item);
        }

        public void Sell(InventoryProduct product, int quantity)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.DecreaseStock(quantity);
        }

        public void UpdateProduct(InventoryProduct product)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.UpdateDetails(product);
        }

        private void CheckProductExists(InventoryProduct product)
        {
            if (!_items.Exists(item => item.Product.SKU == product.SKU))
            {
                throw new Exception("Product does not exist");
            }
        }

        private InventoryItem FindItemByProduct(InventoryProduct product)
        {
            return _items.First(i => i.Product.SKU == product.SKU);
        }

        private int GenerateId()
        {
            if (Items.Count == 0)
                return 0;

            return _items.Max(i => i.Id) + 1;
        }

        private readonly List<InventoryItem> _items = new List<InventoryItem>();
    }
}
