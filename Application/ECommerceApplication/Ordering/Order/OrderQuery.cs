using MediatR;

namespace ECommerceApplication.Ordering.Order
{
    public class OrderQuery : IRequest<OrderQueryResult>
    {
        public int Id { get; set; }
    }
}
