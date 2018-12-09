namespace ECommerceDomain.Shopping.Cart
{
    public interface ICartRepository
    {
        Cart FindById(int id);

        void Update(Cart cart);
    }
}
