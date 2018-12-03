using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Pages
{
    public class OrdersQueryHandler : IRequestHandler<OrdersQuery, OrdersQueryResult>
    {
        public OrdersQueryHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<OrdersQueryResult> Handle(OrdersQuery request, CancellationToken cancellationToken)
        {
            var orderDTOs = _db.Orders.Include(o => o.CustomerDTO).Include(o => o.OrderLines);
            var orders = new List<OrderViewModel>();

            foreach (var order in orderDTOs)
            {
                orders.Add(new OrderViewModel
                {
                    Id = order.Id,
                    DateTime = order.DateTime,
                    CustomerId = order.CustomerId,
                    StreetAddress = order.Street,
                    City = order.City,
                    State = order.State,
                    Country = order.Country,
                    Zipcode = order.Zipcode
                });
            }

            var result = new OrdersQueryResult
            {
                Orders = orders
            };

            return result;
        }

        private ECommerceContext _db;
    }
}
