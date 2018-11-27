using System.Collections.Generic;
using ECommerceDomain.Sales.Cart;

namespace ECommerceDomain.Sales.Order
{
    public class Order
    {
        public int CustomerId { get; }
        private IReadOnlyList<Item> items;

        public Order(Customer.Customer customer, IReadOnlyList<Item> items)
        {
            CustomerId = customer.Id;
            this.items = items;
        }
    }
}
