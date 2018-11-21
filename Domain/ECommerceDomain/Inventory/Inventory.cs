using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Inventory
{
    public class Inventory
    {
        public IReadOnlyList<InventoryItem> Items => _items.ToList();

        public int ItemCount
        {
            get { return _items.Sum(i => i.Stock); }
        }

        public decimal Value
        {
            get { return _items.Sum(i => i.Stock * i.UnitCost); }
        }

        public void TrackProduct(Product product)
        {
            var item = new InventoryItem(product);

            _items.Add(item);
        }

        public void UntrackProduct(Product product)
        {
            CheckProductExists(product);

            _items.RemoveAll(item => item.SKU == product.SKU);
        }

        public void Purchase(Product product, int quantity)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.IncreaseStock(quantity);
        }

        public void Sell(Product product, int quantity)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.DecreaseStock(quantity);
        }

        public void UpdateProduct(Product product)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.UpdateDetails(product);
        }

        private void CheckProductExists(Product product)
        {
            if (!_items.Exists(item => item.SKU == product.SKU))
            {
                throw new Exception("Product does not exist");
            }
        }

        private InventoryItem FindItemByProduct(Product product)
        {
            return _items.First(i => i.SKU == product.SKU);
        }

        private readonly List<InventoryItem> _items = new List<InventoryItem>();
    }
}
