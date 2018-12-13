using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerceDomain.Shopping.Product
{
    public interface IProductRepository
    {
        Product GetBySKU(string sku);

        Task RemoveBySKU(string sku);

        IList<Product> GetAllProducts();
    }
}
