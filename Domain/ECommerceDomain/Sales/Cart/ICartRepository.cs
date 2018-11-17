namespace ECommerceDomain.Sales.Cart
{
    public interface ICartRepository
    {
        Cart FindById(string id);
    }
}
