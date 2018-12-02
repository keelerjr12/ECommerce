using System.Collections.Generic;

namespace ECommerceDomain.Sales.Product
{
    public interface IProductRepository
    {
        Product FindBySku(string sku);

        IList<Product> GetAllProducts();
    }
}
