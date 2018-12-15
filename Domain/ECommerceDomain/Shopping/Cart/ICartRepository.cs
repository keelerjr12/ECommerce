using System;

namespace ECommerceDomain.Shopping.Cart
{
    public interface ICartRepository
    {
        Cart FindById(Guid id);

        void Update(Cart cart);
    }
}
