namespace ECommerceDomain.InventoryManagement.Inventory
{
    public interface IInventoryRepository
    {
        Inventory Get();
        void Save(Inventory inventory);
    }
}
