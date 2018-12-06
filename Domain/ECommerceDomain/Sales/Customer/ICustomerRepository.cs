namespace ECommerceDomain.Sales.Customer
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
    }
}
