﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.InventoryManagement.Inventory
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

        public Product.Product TrackProduct(string sku, string description, string category, decimal unitCost)
        {
            var product = new Product.Product(sku, description, category);

            var item = new InventoryItem(product, unitCost, new List<InventoryItemEntry>());

            _items.Add(product.SKU, item);

            return product;
        }

        public void UntrackProduct(Product.Product product)
        {
            CheckProductExists(product);

            _items.Remove(product.SKU);
        }

        public void ChangeProductUnitPrice(Product.Product product, decimal unitCost)
        {
            CheckProductExists(product);

            var item = _items[product.SKU];
            item.ChangeUnitCost(unitCost);
        }

        public void Purchase(Product.Product product, int quantity, DateTime dateOccurred)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.Purchase(quantity, dateOccurred);
        }

        public void Sell(Product.Product product, int quantity, DateTime dateOccurred)
        {
            CheckProductExists(product);

            var item = FindItemByProduct(product);
            item.Sell(quantity, dateOccurred);
        }

        private void CheckProductExists(Product.Product product)
        {
            if (!_items.ContainsKey(product.SKU))
            {
                throw new Exception("Product does not exist");
            }
        }

        private InventoryItem FindItemByProduct(Product.Product product)
        {
            return _items[product.SKU];
        }

        private readonly Dictionary<string, InventoryItem> _items = new Dictionary<string, InventoryItem>();
    }
}
