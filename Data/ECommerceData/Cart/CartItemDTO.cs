using ECommerceData.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Cart
{
    [Table("CartItems")]
    public class CartItemDTO
    {
        [Column("CartID")]
        public int CartId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        public CartDTO Cart { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual ProductDTO Product { get; set; }
    }
}
