using ECommerceData.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Cart
{
    [Table("CartItems")]
    internal class CartItemDTO
    {
        [Column("CartID")]
        public int CartId { get; set; }

        [Column("ProductSKU")]
        public string ProductSKU { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        public CartDTO Cart { get; set; }
        
        [ForeignKey("ProductSKU")]
        public virtual ProductDTO Product { get; set; }
    }
}
