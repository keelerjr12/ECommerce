﻿using System.Linq;
using System.Threading.Tasks;
using ECommerceDomain.Shopping.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Shopping.Product
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Shopping.Product.Product GetBySKU(string sku)
        {
            var productDTO = _eCommerceContext.Products.Include(p => p.ProductCategory).First(p => p.SKU == sku);

            var product = new ECommerceDomain.Shopping.Product.Product(productDTO.Id, productDTO.SKU, productDTO.Name, productDTO.Manufacturer, productDTO.Description, productDTO.Price, productDTO.CategoryId, productDTO.ImageFileName);

            return product;
        }

        public async Task SaveAsync(ECommerceDomain.Shopping.Product.Product product)
        {
            var exists = _eCommerceContext.Products.AnyAsync(p => p.SKU == product.SKU).Result;

            if (exists)
            {
                var productDTO = await _eCommerceContext.Products.FirstAsync(p => p.SKU == product.SKU);
                productDTO.SKU = product.SKU;
                productDTO.Name = product.Name;
                productDTO.Manufacturer = product.Manufacturer;
                productDTO.Description = product.Description;
                productDTO.Price = product.Price;
                productDTO.CategoryId = product.CategoryId;
                productDTO.Status = product.Status;
                productDTO.ImageFileName = product.ImageFileName;
            }
            else
            {
                var productDTO = new ProductDTO
                {
                    SKU = product.SKU,
                    Name = product.Name,
                    Manufacturer = product.Manufacturer,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Status = product.Status,
                    ImageFileName = product.ImageFileName
                };

                _eCommerceContext.Products.Add(productDTO);
            }

        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
