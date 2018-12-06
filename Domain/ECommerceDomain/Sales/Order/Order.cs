using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Common;
using ECommerceDomain.Sales.Common;

namespace ECommerceDomain.Sales.Order
{
    public class Order
    {
        public int Id { get; }
        public int CustomerId { get; }
        public DateTime Created { get; }
        public Address ShippingAddress { get; }
        public Address BillingAddress { get; }
        public IReadOnlyList<OrderLine> OrderLines => _orderLines.ToList();

        public Order(int customerId, Address billing, Address shipping, IReadOnlyList<LineItem> items)
        {
            var orderLines = new List<OrderLine>();
            foreach (var item in items)
            {
                //orderLines.Add(new OrderLine(item.SKU, item.Quantity.Value, item.Price));
            }

            Id = 0;
            CustomerId = customerId;
            Created = DateTime.Now;
            ShippingAddress = shipping;
            BillingAddress = billing;
            _orderLines = orderLines;
        }

        public Order(int id, int customerId, DateTime created, Address shipping, Address billing, IReadOnlyList<OrderLine> orderLines)
        {
            Id = id;
            CustomerId = customerId;
            Created = created;
            ShippingAddress = shipping;
            BillingAddress = billing;
            _orderLines = orderLines.ToList();
        }

        private readonly List<OrderLine> _orderLines;
    }
}
