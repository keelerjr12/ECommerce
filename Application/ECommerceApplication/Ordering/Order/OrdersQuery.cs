using MediatR;

namespace ECommerceApplication.Ordering.Order
{
    public class OrdersQuery : IRequest<OrdersQueryResult>
    {
        public string Status { get; set; }
    }
}