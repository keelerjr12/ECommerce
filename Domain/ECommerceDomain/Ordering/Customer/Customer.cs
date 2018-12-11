using System.Collections.Generic;
using ECommerceDomain.Common;
using ECommerceDomain.Ordering.Events;
using ECommerceDomain.Shopping.Common;

namespace ECommerceDomain.Ordering.Customer
{
    public class Customer : AggregateRoot
    {
        private int Id { get; }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public Address Shipping { get; private set; }
        public Address Billing { get; }

        public Customer(int id, string firstName, string middleName, string lastName, Address billing, Address shipping)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Billing = billing;
            Shipping = shipping;
        }

        public Order.Order PlaceOrder(List<LineItem> items)
        {
            var order = new Order.Order(Id, Billing, Shipping, items);

            return order;
        }

        public void UpdateShippingAddress(Address newShipping)
        {
            Shipping = newShipping;
        }
    }
}
