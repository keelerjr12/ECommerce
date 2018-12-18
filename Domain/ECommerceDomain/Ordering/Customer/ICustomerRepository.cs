using System;

namespace ECommerceDomain.Ordering.Customer
{ 
    public interface ICustomerRepository
    {
        Customer GetById(Guid id);
        void Update(Customer customer);
    }
}
