﻿using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Common;
using ECommerceDomain.Sales.Cart;

namespace ECommerceDomain.Sales.Order
{
    public class Order
    {
        public int Id { get; }
        public int CustomerId { get; }
        public DateTime Created { get; }
        public Address ShippingAddress { get; }
        public Address BillingAddress { get; }
        public IReadOnlyList<OrderLine> OrderLines => _ordersLines.ToList();

        public static Order Create(int customerId, Address shipping, Address billing, IReadOnlyList<Item> items)
        {
            var orderLines = new List<OrderLine>();
            foreach (var item in items)
            {
                orderLines.Add(new OrderLine(item.SKU, item.Quantity.Value, item.Price));
            }

            return new Order(0, customerId, DateTime.Now, shipping, billing, orderLines);
        }

        public Order(int id, int customerId, DateTime created, Address shipping, Address billing, IReadOnlyList<OrderLine> orderLines)
        {
            Id = id;
            CustomerId = customerId;
            Created = created;
            ShippingAddress = shipping;
            BillingAddress = billing;
            _ordersLines = orderLines.ToList();
        }

        private readonly List<OrderLine> _ordersLines;
    }
}
