using MediatR;

namespace ECommerceWeb.Pages
{
    public class CustomerQueryRequest : IRequest<CustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }
}
