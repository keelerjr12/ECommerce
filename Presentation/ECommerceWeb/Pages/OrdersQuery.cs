using MediatR;

namespace ECommerceWeb.Pages
{
    public class OrdersQuery : IRequest<OrdersQueryResult>
    {
        public string Status { get; set; }
    }
}