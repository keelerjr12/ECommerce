﻿using System.Linq;
using ECommerceDomain.Inventory.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Inventory.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Inventory.Product.Product GetBySKU(string sku)
        {
            var productDTO = _eCommerceContext.InventoryProducts.Include(p => p.Product).First(p => p.Product.SKU == sku);

            var product =
                new ECommerceDomain.Inventory.Product.Product(productDTO.Product.SKU, productDTO.Description, productDTO.Category);

            return product;
        }

        public void Update(ECommerceDomain.Inventory.Product.Product product)
        {
            var productExists = _eCommerceContext.InventoryProducts.Any(p => p.Product.SKU == product.SKU);

            if (!productExists)
            {
                var productToAdd = _eCommerceContext.Products.First(p => p.SKU == product.SKU);

                var productDTO = new ProductDTO
                {
                    Id = productToAdd.Id,
                    Category = product.Category,
                    Description = product.Description
                };

                _eCommerceContext.InventoryProducts.Add(productDTO);
            }
            else
            {
                var productDTO = _eCommerceContext.InventoryProducts.First(p => p.Product.SKU == product.SKU);

                productDTO.Description = product.Description;
                productDTO.Category = product.Category;
            }
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
