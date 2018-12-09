using System.Collections.Generic;

namespace ECommerceDomain.Shopping.Product
{
    public interface IProductRepository
    {
        Product FindBySku(string sku);

        IList<Product> GetAllProducts();
    }
}
