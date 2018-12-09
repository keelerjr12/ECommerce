namespace ECommerceDomain.Ordering.Customer
{ 
    public interface ICustomerRepository
    {
        Customer GetById(int id);
    }
}
