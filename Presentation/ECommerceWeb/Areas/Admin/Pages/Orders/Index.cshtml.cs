using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceApplication.Ordering.Order;
using ECommerceApplication.Ordering.Order.Queries;
using ECommerceWeb.Areas.Admin.Models.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Areas.Admin.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        public List<OrderViewModel> Orders { get; private set; }

        public OrdersModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var orderResult = await _mediator.Send(new OrdersQuery.Request
            {
                Status = "All"
            });
            var orders = orderResult.Orders;

            Orders = Mapper.Map<List<OrderDTO>, List<OrderViewModel>>(orders);
        }

        private readonly IMediator _mediator;
    }
}