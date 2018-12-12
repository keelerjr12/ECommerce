using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Ordering.Customer.Queries
{
    public class CustomerQuery
    {
        public class Request : IRequest<Result>
        {
            public int CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var customerDTO = await _db.Customers.FindAsync(request.CustomerId);

                var result = new Result()
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

        public class Result
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public int ZipCode { get; set; }
        }
    }
}
