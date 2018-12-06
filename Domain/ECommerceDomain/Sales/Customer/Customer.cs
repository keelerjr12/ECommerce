using System.Collections.Generic;
using ECommerceDomain.Common;
using ECommerceDomain.Sales.Common;

namespace ECommerceDomain.Sales.Customer
{
    public class Customer
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
            return new Order.Order(Id, Billing, Shipping, items);
        }

        public void UpdateShippingAddress(Address newShipping)
        {
            Shipping = newShipping;
        }
    }
}
