using MediatR;

namespace ECommerceWeb.Pages
{
    public class TopSellingProductsQuery : IRequest<TopSellingProductsResult>
    {
        public int NumberOfProducts { get; set; }
    }
}
