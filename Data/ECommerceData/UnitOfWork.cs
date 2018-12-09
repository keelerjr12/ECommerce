namespace ECommerceData
{
    public class UnitOfWork
    {
        public UnitOfWork(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public void Save()
        {
            _eCommerceContext.SaveChanges();
        }

        private readonly ECommerceContext _eCommerceContext;
    }
}
