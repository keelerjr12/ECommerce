namespace ECommerceDomain.Sales.Cart
{
    public interface ICartRepository
    {
        Cart FindById(int id);

        void Update(Cart cart);
    }
}
