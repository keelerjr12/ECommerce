using MediatR;

namespace ECommerceApplication.Sales.Customer
{
    public class CustomerQueryRequest : IRequest<CustomerQueryResult>
    {
        public int CustomerId { get; set; }
    }
}
