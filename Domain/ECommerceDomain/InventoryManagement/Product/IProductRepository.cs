namespace ECommerceDomain.InventoryManagement.Product
{
    public interface IProductRepository
    {
        Product GetBySKU(int inventoryId, string sku);
        void Update(Product product);
    }
}
