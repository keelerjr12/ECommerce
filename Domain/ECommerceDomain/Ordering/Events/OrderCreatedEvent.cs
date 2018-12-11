using System;
using ECommerceDomain.Common;

namespace ECommerceDomain.Ordering.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public OrderCreatedEvent(DateTime created, string sku, int quantity)
        {
            Created = created;
            SKU = sku;
            Quantity = quantity;
        }

        public DateTime Created { get; }
        public string SKU { get; }
        public int Quantity { get; }
    }
}
