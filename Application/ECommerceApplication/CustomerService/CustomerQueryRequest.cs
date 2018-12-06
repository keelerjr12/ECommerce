using MediatR;

namespace ECommerceApplication.CustomerService
{
    public class CustomerQueryRequest : IRequest<CustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }
}
