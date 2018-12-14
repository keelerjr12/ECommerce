using System.Collections.Generic;

namespace ECommerceData.Shopping.Cart
{
    public class CartDTO
    {
        public int Id { get; set; }

        public List<CartItemDTO> CartItems { get; set; }
    }
}
