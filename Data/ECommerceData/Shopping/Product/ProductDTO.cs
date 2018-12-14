using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Shopping.ProductCategory;

namespace ECommerceData.Shopping.Product
{
    [Table("Product")]
    public class ProductDTO
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public string ImageFileName { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategoryDTO ProductCategory { get; set; }
    }
}
