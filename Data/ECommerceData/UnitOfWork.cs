namespace ECommerceData
{
    public class UnitOfWork
    {
        public UnitOfWork(ECommerceContext eCommcereContext)
        {
            _eCommerceContext = eCommcereContext;
        }

        public void Save()
        {
            _eCommerceContext.SaveChanges();
        }

        private ECommerceContext _eCommerceContext;
    }
}
