using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Ordering.Order.Queries
{
    public class OrderQuery
    {
        public class Request : IRequest<Result>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var orderDTO = _db.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines).First(o => o.Id == request.Id);

                var orderLines = new List<OrderLineDTO>();
                foreach (var orderLine in orderDTO.OrderLines)
                {
                    orderLines.Add(new OrderLineDTO
                    {
                        SKU = orderLine.SKU,
                        Price = orderLine.Price,
                        Quantity = orderLine.Quantity
                    });
                }

                var result = new Result
                {
                    Id = orderDTO.Id,
                    Created = orderDTO.Created,
                    CustomerId = orderDTO.CustomerId,
                    Street = orderDTO.Street,
                    City = orderDTO.City,
                    State = orderDTO.State,
                    Country = orderDTO.Country,
                    Zipcode = orderDTO.Zipcode,
                    OrderLines = orderLines
                };

                return result;
            }

            private readonly ECommerceContext _db;
        }
    }

    public class Result
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public int CustomerId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }

        public List<OrderLineDTO> OrderLines { get; set; }
    }
}
