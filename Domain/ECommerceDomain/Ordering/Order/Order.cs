using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Common;
using ECommerceDomain.Ordering.Events;
using ECommerceDomain.Shopping.Common;

namespace ECommerceDomain.Ordering.Order
{
    public class Order : AggregateRoot
    {
        public int Id { get; }
        public Guid CustomerId { get; }
        public DateTime Created { get; }
        public Address ShippingAddress { get; }
        public Address BillingAddress { get; }
        public decimal ShippingCost { get; }
        public IReadOnlyList<OrderLine> OrderLines => _orderLines.ToList();

        public Order(Guid customerId, Address billing, Address shipping, IReadOnlyList<LineItem> items, decimal shippingCost)
        {
            var orderLines = new List<OrderLine>();
            foreach (var item in items)
            {
                orderLines.Add(new OrderLine(item.SKU, item.Quantity, item.Price));
            }

            Id = 0;
            CustomerId = customerId;
            Created = DateTime.Now;
            ShippingAddress = shipping;
            BillingAddress = billing;
            _orderLines = orderLines;
            ShippingCost = shippingCost;

            AddEvent(new OrderCreatedEvent(Created, items[0].SKU, items[0].Quantity));
        }

        public Order(int id, Guid customerId, DateTime created, Address shipping, Address billing, IReadOnlyList<OrderLine> orderLines, decimal shippingCost)
        {
            Id = id;
            CustomerId = customerId;
            Created = created;
            ShippingAddress = shipping;
            BillingAddress = billing;
            ShippingCost = ShippingCost;
            _orderLines = orderLines.ToList();
        }

        private readonly List<OrderLine> _orderLines;

    }
}
