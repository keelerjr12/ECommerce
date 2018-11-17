﻿using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Common;

namespace ECommerceDomain.Sales.Cart
{
    public class Cart
    {
        public Quantity ItemCount => Quantity.Is(_items.Sum(item => item.Quantity.Value));
        public decimal Subtotal =>_items.Sum(item => item.Price * item.Quantity.Value);

        public IReadOnlyList<Item> Items => _items.ToList();

        public void Add(Product.Product product, Quantity quantity)
        {
            var item = _items.Find(itemToSearch => itemToSearch.SKU == product.SKU);

            if (item != null)
            {
                item.IncreaseQuantity(quantity);
            }
            else
            {
                var itemToAdd = new Item(product, quantity);
                _items.Add(itemToAdd);
            }
        }

        public void Remove(Product.Product product, Quantity quantity)
        {
            var item = _items.Find(itemToSearch => itemToSearch.SKU == product.SKU);

            if (item == null)
                throw new ItemNotFoundException(product);

            item.DecreaseQuantity(quantity);

            if (item.Quantity == Quantity.Zero)
            {
                _items.Remove(item);
            }
        }

        public void Delete(Product.Product product)
        {
            var item = _items.Find(itemToSearch => itemToSearch.SKU == product.SKU);

            if (item == null)
                throw new ItemNotFoundException(product);

            _items.Remove(item);
;        }

        private readonly List<Item> _items = new List<Item>();
    }
}
