using System.Collections.Generic;

namespace ECommerceDomain.Sales.Product
{
    public interface IProductRepository
    {
        Product FindBySku(string sku);

        IReadOnlyList<Product> GetAllProducts();
    }
}
