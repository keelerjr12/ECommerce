using System.Collections.Generic;

namespace ECommerceData.Inventory
{
    internal class InventoryDTO
    {
        public int Id { get; set; }

        public List<InventoryItemDTO> InventoryItems { get; set; }
    }
}