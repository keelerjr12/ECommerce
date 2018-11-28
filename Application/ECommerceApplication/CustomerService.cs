using ECommerceDomain.Sales.Customer;

namespace ECommerceApplication
{
    public class CustomerService
    {
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Customer GetCustomer(int id)
        {
            return _customerRepo.GetById(id);
        }

        private readonly ICustomerRepository _customerRepo;
    }
}
