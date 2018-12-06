using ECommerceWeb.Pages;
using MediatR;

namespace ECommerceApplication.OrderService
{
    public class OrdersQuery : IRequest<OrdersQueryResult>
    {
        public string Status { get; set; }
    }
}