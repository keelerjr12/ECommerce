using System;
using System.Linq;
using ECommerceDomain.Common;
using ECommerceDomain.Ordering.Customer;

namespace ECommerceData.Ordering.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Ordering.Customer.Customer GetById(Guid id)
        {
            var customerDTO = _eCommerceContext.Customers.First(c => c.Id == id);

            var shippingAddress = new Address(customerDTO.Street, customerDTO.City, customerDTO.State,
                "United States", customerDTO.ZipCode);
            var billingAddress = new Address(customerDTO.Street, customerDTO.City, customerDTO.State,
                "United States", customerDTO.ZipCode);

            var customer = new ECommerceDomain.Ordering.Customer.Customer(customerDTO.Id, customerDTO.FirstName, customerDTO.MiddleName, customerDTO.LastName, billingAddress, shippingAddress);

            return customer;
        }

        public void Update(ECommerceDomain.Ordering.Customer.Customer customer)
        {
            var customerDTO = _eCommerceContext.Customers.First(c => c.Id == customer.Id);
            customerDTO.IsSubscribed = customer.IsSubscribed;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
