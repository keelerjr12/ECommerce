using MediatR;

namespace ECommerceApplication.Ordering.Customer
{
    public class CustomerQueryRequest : IRequest<CustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }
}
