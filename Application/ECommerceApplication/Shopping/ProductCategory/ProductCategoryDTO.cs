namespace ECommerceApplication.Shopping.ProductCategory
{
    public class ProductCategoryDTO
    {
        public int Id { get; }
        public string Name { get; }

        public ProductCategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
