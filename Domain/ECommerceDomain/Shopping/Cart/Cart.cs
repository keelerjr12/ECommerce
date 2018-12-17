using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Shopping.Common;

namespace ECommerceDomain.Shopping.Cart
{
    public class Cart
    {
        public Guid Id;

        public Quantity ItemCount => Quantity.Is(_items.Sum(item => item.Quantity.Value));

        public decimal Subtotal => _items.Sum(item => item.Price * item.Quantity.Value);

        public IReadOnlyList<CartItem> Items => _items.ToList();

        public Cart(Guid id)
        {
            Id = id;
        }

        public void Add(Product.Product product, Quantity quantity)
        {
            var item = _items.Find(itemToSearch => itemToSearch.SKU == product.SKU);

            if (item != null)
            {
                item.IncreaseQuantity(quantity);
            }
            else
            {
                var itemToAdd = new CartItem(product, quantity);
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

        public void Empty()
        {
            _items.Clear();
        }

        private readonly List<CartItem> _items = new List<CartItem>();
    }
}