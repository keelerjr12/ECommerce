using MediatR;

namespace ECommerceApplication.Sales.Order
{
    public class OrdersQuery : IRequest<OrdersQueryResult>
    {
        public string Status { get; set; }
    }
}