using System.Linq;
using ECommerceDomain.Sales.Customer;

namespace ECommerceData.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Sales.Customer.Customer GetById(int id)
        {
            var customerDTO = _eCommerceContext.Customers.First(c => c.Id == id);

            var customer = new ECommerceDomain.Sales.Customer.Customer(customerDTO.Id, customerDTO.FirstName, customerDTO.MiddleName,
                customerDTO.LastName, customerDTO.StreetAddress, customerDTO.ZipCode);

            return customer;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
