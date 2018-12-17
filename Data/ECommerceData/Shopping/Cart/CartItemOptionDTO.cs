using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Shopping.Cart
{
    [Table("CartItemOption")]
    public class CartItemOptionDTO
    {
        public int Id { get; set; }

        public int CartItemId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        [ForeignKey("CartItemId")]
        public CartItemDTO CartItemDTO { get; set; }
    }
}