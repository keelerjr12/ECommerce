using System.Collections.Generic;
using ECommerceDomain.Common;
using ECommerceDomain.Ordering;
using ECommerceDomain.Ordering.Customer;
using Xunit;

namespace ECommerceDomainTests.Ordering
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerPlacesOrder_Returns_ValidOrder()
        {
            var items = new List<LineItem>();
            var shipping = new Address("test_street", "test_city", "test_state", "test_country", 00000);
            var billing = new Address("test_street", "test_city", "test_state", "test_country", 00000);

            var customer = new Customer(0, "TestFirstName", "TestMiddleName", "TestLastName", billing, shipping);
            var order = customer.PlaceOrder(items);

            Assert.NotNull(order);
        }

        [Fact]
        public void CustomerUpdatesShippingAddressBeforePlacingOrder_Returns_OrderWithNewShippingAddress()
        {
            var items = new List<LineItem>();
            var shipping = new Address("test_street", "test_city", "test_state", "test_country", 00000);
            var billing = new Address("test_street", "test_city", "test_state", "test_country", 00000);

            var customer = new Customer(0, "TestFirstName", "TestMiddleName", "TestLastName", billing, shipping);
            customer.UpdateShippingAddress(new Address("newStreet", "newCity", "newState", "newCountry", 11111));

            var order = customer.PlaceOrder(items);

            Assert.Equal(customer.Shipping, order.ShippingAddress);
        }
    }
}
