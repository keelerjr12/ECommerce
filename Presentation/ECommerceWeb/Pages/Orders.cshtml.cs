using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceApplication;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages
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
            var orderResult = await _mediator.Send(new OrdersQuery
            {
                Status = "All"
            });

            Orders = orderResult.Orders;
        }

        private readonly IMediator _mediator;
    }
}