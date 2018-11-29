using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.InventoryManagement.Inventory
{
    [Table("Inventory")]
    public class InventoryDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        public List<InventoryItemDTO> InventoryItems { get; set; }
    }
}