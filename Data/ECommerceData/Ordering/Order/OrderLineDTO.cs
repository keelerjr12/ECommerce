using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Ordering.Order
{
    [Table("OrderLine")]
    public class OrderLineDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("OrderId")]
        public int OrderId { get; set; }

        public string SKU { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public OrderDTO Order { get; set; }
    }
}