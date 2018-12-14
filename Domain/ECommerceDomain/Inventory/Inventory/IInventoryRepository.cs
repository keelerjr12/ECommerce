namespace ECommerceDomain.Inventory.Inventory
{
    public interface IInventoryRepository
    {
        Inventory Get();
        void Save(Inventory inventory);
    }
}
