namespace ECommerceDomain.Inventory
{
    public interface IInventoryProductRepository
    {
        InventoryProduct GetBySKU(string sku);
    }
}
