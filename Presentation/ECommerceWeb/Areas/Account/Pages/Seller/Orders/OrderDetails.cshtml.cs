using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication.Ordering.Order.Queries;
using ECommerceWeb.Areas.Admin.Models.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Account.Pages.Seller.Orders
{
    public class OrderDetailsModel : PageModel
    {
        public OrderViewModel OrderVM { get; private set; }
        public IList<OrderLineVM> OrderLines { get; } = new List<OrderLineVM>();

        public OrderDetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync(string id)
        {
            var orderId = int.Parse(id);

            var order = await _mediator.Send(new OrderQuery.Request
            {
                Id = orderId
            });

            OrderVM = new OrderViewModel
            {
                Id = order.Id,
                Created = order.Created,
                CustomerId = order.CustomerId,
                StreetAddress = order.Street,
                City = order.City,
                State = order.State,
                Country = order.Country,
                Zipcode = order.Zipcode
            };

            foreach (var orderLine in order.OrderLines)
            {
                OrderLines.Add(new OrderLineVM
                {
                    SKU = orderLine.SKU,
                    Quantity = orderLine.Quantity,
                    Price = orderLine.Price
                });
            }
        }

        private readonly IMediator _mediator;
    }
}