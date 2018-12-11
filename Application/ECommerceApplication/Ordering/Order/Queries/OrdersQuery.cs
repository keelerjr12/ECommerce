using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Ordering.Order.Queries
{
    public class OrdersQuery
    {
        public class Request : IRequest<Result>
        {
            public string Status { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var orderDTOs = _db.Orders.Include(o => o.CustomerDTO);
                var orders = new List<OrderDTO>();

                foreach (var order in orderDTOs)
                {
                    orders.Add(new OrderDTO
                    {
                        Id = order.Id,
                        Created = order.Created,
                        CustomerId = order.CustomerId,
                        StreetAddress = order.Street,
                        City = order.City,
                        State = order.State,
                        Country = order.Country,
                        Zipcode = order.Zipcode
                    });
                }

                var result = new Result
                {
                    Orders = orders
                };

                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public List<OrderDTO> Orders { get; set; }
        }
    }
}