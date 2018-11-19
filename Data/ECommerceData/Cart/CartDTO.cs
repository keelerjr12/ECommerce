using System.Collections.Generic;

namespace ECommerceData.Cart
{
    internal class CartDTO
    {
        public int Id { get; set; }

        public List<CartItemDTO> CartItems { get; set; }
    }
}
