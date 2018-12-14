using System.Threading.Tasks;

namespace ECommerceDomain.Shopping.ProductCategory
{
    public interface IProductCategoryRepository
    {
       Task SaveAsync(ProductCategory category);
    }
}
