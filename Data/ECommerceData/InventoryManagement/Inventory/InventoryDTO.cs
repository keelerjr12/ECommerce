using System.Collections.Generic;

namespace ECommerceData.InventoryManagement.Inventory
{
    public class InventoryDTO
    {
        public int Id { get; set; }

        public List<InventoryItemDTO> InventoryItems { get; set; }
    }
}