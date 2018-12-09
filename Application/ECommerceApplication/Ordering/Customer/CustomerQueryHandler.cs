using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Ordering.Customer
{
    public class CustomerQueryHandler : IRequestHandler<CustomerQueryRequest, CustomerQueryResult>
    {
        public CustomerQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<CustomerQueryResult> Handle(CustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customerDTO = await _db.Customers.FindAsync(request.CustomerId);

            var result = new CustomerQueryResult
            {
                Id = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                MiddleName = customerDTO.MiddleName,
                LastName = customerDTO.LastName,
                Street = customerDTO.Street,
                City = customerDTO.City,
                State = customerDTO.State,
                Country = customerDTO.Country,
                ZipCode = customerDTO.ZipCode
            };

            return result;
        }

        private readonly ECommerceContext _db;
    }
}
