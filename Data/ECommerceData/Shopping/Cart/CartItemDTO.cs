using System;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Ordering.Customer;
using ECommerceData.Shopping.Product;

namespace ECommerceData.Shopping.Cart
{
    [Table("CartItems")]
    public class CartItemDTO
    {
        [Column("CustomerId")]
        public Guid CustomerId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerDTO CustomerDTO { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual ProductDTO Product { get; set; }
    }
}
