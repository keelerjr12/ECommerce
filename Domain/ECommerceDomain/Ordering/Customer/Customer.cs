﻿using System;
using System.Collections.Generic;
using ECommerceDomain.Common;
using ECommerceDomain.Shopping.Common;

namespace ECommerceDomain.Ordering.Customer
{
    public class Customer : AggregateRoot
    {
        public Guid Id { get; }

        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public Address Shipping { get; private set; }
        public Address Billing { get; }

        public bool IsSubscribed { get; private set; }

        public Customer(Guid id, string firstName, string middleName, string lastName, Address billing, Address shipping)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Billing = billing;
            Shipping = shipping;
        }

        public Order.Order PlaceOrder(List<LineItem> items, decimal shippingCost)
        {
            var order = new Order.Order(Id, Billing, Shipping, items, shippingCost);

            return order;
        }

        public void UpdateShippingAddress(Address newShipping)
        {
            Shipping = newShipping;
        }

        public void UpdateSubscription(bool isSubscribed)
        {
            IsSubscribed = isSubscribed;
        }
    }
}
