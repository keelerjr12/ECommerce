using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Ordering.Customer;
using ECommerceData.Shopping.Product;

namespace ECommerceData.Shopping.Cart
{
    [Table("CartItem")]
    public class CartItemDTO
    {
        public int Id { get; set; }

        [Column("CustomerId")]
        public Guid CustomerId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        public List<CartItemOptionDTO> Options { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerDTO CustomerDTO { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual ProductDTO Product { get; set; }
    }
}
