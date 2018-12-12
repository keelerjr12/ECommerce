using System.Collections.Generic;

namespace ECommerceData.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }

        public List<CartItemDTO> CartItems { get; set; }
    }
}
