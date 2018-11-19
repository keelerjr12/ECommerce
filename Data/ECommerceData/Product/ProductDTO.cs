using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Product
{
    [Table("Product")]
    internal class ProductDTO
    {
        [Key]
        [Column("SKU")]
        public string SKU { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
