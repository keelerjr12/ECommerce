﻿using ECommerceDomain.Sales.Common;

namespace ECommerceDomain.Sales.Cart
{
    public class Item
    {
        public int ProductId { get; set; }

        public string SKU { get; }

        public string Description { get; }

        public decimal Price { get; }

        public Quantity Quantity { get; private set; }

        public Item(Product.Product product, Quantity quantity)
        {
            ProductId = product.Id;
            SKU = product.SKU;
            Description = product.Description;
            Price = product.Price;
            Quantity = quantity;
        }

        public void IncreaseQuantity(Quantity quantity)
        {
            Quantity += quantity;
        }

        public void DecreaseQuantity(Quantity quantity)
        {
            Quantity -= quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is Item other && SKU == other.SKU;
        }

        public override int GetHashCode()
        {
            return SKU.GetHashCode();
        }
    }
}
