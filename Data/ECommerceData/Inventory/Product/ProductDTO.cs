using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Inventory.Product
{
    [Table("InventoryProduct")]
    public class ProductDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [ForeignKey("Id")]
        public ECommerceData.Product.ProductDTO Product { get; set; }
    }
}
