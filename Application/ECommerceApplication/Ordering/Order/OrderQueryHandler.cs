using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Ordering.Order
{
    public class OrderQueryHandler : IRequestHandler<OrderQuery, OrderQueryResult>
    {
        public OrderQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<OrderQueryResult> Handle(OrderQuery request, CancellationToken cancellationToken)
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

            var result = new OrderQueryResult
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
