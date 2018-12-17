using System.Threading.Tasks;

namespace ECommerceDomain.Shopping.Product
{
    public interface IProductRepository
    {
        Product GetBySKU(string sku);

        Task SaveAsync(Product product);
    }
}
