using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Sales.Cart;

namespace ECommerceDomain.Sales.Order
{
    public class Order
    {
        public int Id { get; }

        public DateTime DateTime { get; }

        public Customer.Customer Customer { get; }
        public IReadOnlyList<OrderLine> OrderLines => _ordersLines.ToList();

        public Order(Customer.Customer customer, IReadOnlyList<Item> items)
        {
            DateTime = DateTime.Now;

            Customer = customer;

            foreach (var item in items)
            {
                _ordersLines.Add(new OrderLine(item.SKU, item.Quantity.Value, item.Price));
            }
        }

        public Order(int id, DateTime dateTime, Customer.Customer customer, IReadOnlyList<OrderLine> orderLines)
        {
            Id = id;

            DateTime = dateTime;

            Customer = customer;

            _ordersLines = orderLines.ToList();
        }


        private readonly List<OrderLine> _ordersLines = new List<OrderLine>();
    }
}
