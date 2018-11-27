using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Customer;

namespace ECommerceData.Order
{
    [Table("Order")]
    internal class OrderDTO
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerDTO Customer { get; set; }
    }
}
