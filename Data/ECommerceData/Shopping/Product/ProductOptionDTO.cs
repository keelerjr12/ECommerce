using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Shopping.Product
{
    [Table("ProductOption")]
    public class ProductOptionDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public List<ProductOptionValueDTO> Values { get; set; }

        [ForeignKey("ProductId")]
        public ProductDTO Product { get; set; }
    }
}