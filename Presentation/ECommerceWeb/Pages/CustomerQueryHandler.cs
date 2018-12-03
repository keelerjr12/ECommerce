using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceWeb.Pages
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
                CustomerId = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                MiddleName = customerDTO.MiddleName,
                LastName = customerDTO.LastName,
                StreetAddress = customerDTO.StreetAddress,
                City = customerDTO.City,
                State = customerDTO.State,
                Country = "United States",
                ZipCode = customerDTO.ZipCode
            };

            return result;
        }

        private readonly ECommerceContext _db;
    }
}
