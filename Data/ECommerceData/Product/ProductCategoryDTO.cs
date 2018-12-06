using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Product
{
    [Table("ProductCategory")]
    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Category { get; set; }
    }
}