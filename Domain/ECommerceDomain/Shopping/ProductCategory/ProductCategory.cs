namespace ECommerceDomain.Shopping.ProductCategory
{
    public class ProductCategory
    {
        public int Id { get; }
        public string Name { get; }

        public ProductCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
