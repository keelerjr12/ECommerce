using System.Linq;
using ECommerceDomain.Inventory;

namespace ECommerceData.Inventory
{
    public class InventoryProductRepository : IInventoryProductRepository
    {

        public InventoryProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Inventory.InventoryProduct GetBySKU(string sku)
        {
            var productDTO = _eCommerceContext.InventoryProducts.First(ip => ip.SKU == sku);

            var product = new InventoryProduct(productDTO.SKU, productDTO.Description, productDTO.Category);

            return product;
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
