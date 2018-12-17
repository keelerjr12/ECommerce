using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Shopping.Product
{
    [Table("ProductOptionValue")]
    public class ProductOptionValueDTO
    {
        public int Id { get; set; }

        public int ProductOptionId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ProductOptionId")]
        public ProductOptionDTO ProductOption { get; set; }
    }
}