namespace ECommerceDomain.InventoryManagement.Product
{
    public interface IProductRepository
    {
        Product GetBySKU(string sku);
        void Update(Product product);
    }
}
