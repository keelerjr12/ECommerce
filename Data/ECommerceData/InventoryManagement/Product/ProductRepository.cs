using System.Linq;
using ECommerceDomain.InventoryManagement.Product;
using Microsoft.EntityFrameworkCore;

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
            var productDTO = _eCommerceContext.InventoryProducts.Include(p => p.Product).First(p => p.InventoryId == inventoryId &&  p.Product.SKU == sku);

            var product =
                new ECommerceDomain.InventoryManagement.Product.Product(productDTO.InventoryId, productDTO.Product.SKU, productDTO.Description, productDTO.Category);

            return product;
        }

        public void Update(ECommerceDomain.InventoryManagement.Product.Product product)
        {
            var productExists = _eCommerceContext.InventoryProducts.Any(p => p.InventoryId == product.InventoryId && p.Product.SKU == product.SKU);

            if (!productExists)
            {
                var productToAdd = _eCommerceContext.Products.First(p => p.SKU == product.SKU);

                var productDTO = new ProductDTO
                {
                    Id = productToAdd.Id,
                    InventoryId = product.InventoryId,
                    Category = product.Category,
                    Description = product.Description
                };

                _eCommerceContext.InventoryProducts.Add(productDTO);
            }
            else
            {
                var productDTO = _eCommerceContext.InventoryProducts.First(p =>
                    p.InventoryId == product.InventoryId && p.Product.SKU == product.SKU);

                productDTO.Description = product.Description;
                productDTO.Category = product.Category;
            }
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
