namespace ECommerceDomain.Inventory.Product
{
    public interface IProductRepository
    {
        Product GetBySKU(string sku);
        void Update(Product product);
    }
}
