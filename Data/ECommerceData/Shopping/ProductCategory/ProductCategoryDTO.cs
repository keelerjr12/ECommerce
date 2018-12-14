using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Shopping.ProductCategory
{
    [Table("ProductCategory")]
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}