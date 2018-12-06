using MediatR;

namespace ECommerceApplication.ProductService
{
    public class TopSellingProductsQuery : IRequest<TopSellingProductsResult>
    {
        public int NumberOfProducts { get; set; }
    }
}
