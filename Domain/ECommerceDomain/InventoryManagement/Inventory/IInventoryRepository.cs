namespace ECommerceDomain.InventoryManagement.Inventory
{
    public interface IInventoryRepository
    {
        Inventory FindById(int id);
        void Update(Inventory inventory);
    }
}
