using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Product
{
    [Table("Product")]
    public class ProductDTO
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }
    }
}
