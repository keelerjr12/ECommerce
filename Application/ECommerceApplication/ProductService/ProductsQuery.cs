using MediatR;

namespace ECommerceApplication.ProductService
{
    public class ProductsQuery : IRequest<ProductsResult>
    {
        public string Category { get; set; }
    }
}
