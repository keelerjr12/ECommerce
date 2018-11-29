using System.Linq;
using ECommerceDomain.InventoryManagement.Product;

namespace ECommerceData.InventoryManagement.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.InventoryManagement.Product.Product GetBySKU(int inventoryId, string sku)
        {
            var productDTO = _eCommerceContext.InventoryProducts.First(p => p.InventoryId == inventoryId &&  p.Product.SKU == sku);

            var product =
                new ECommerceDomain.InventoryManagement.Product.Product(productDTO.Product.SKU, productDTO.Description,
                    productDTO.Category);

            return product;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
