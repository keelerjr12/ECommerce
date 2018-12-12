using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Inventory.Inventory
{
    [Table("InventoryItemEntry")]
    public class InventoryItemEntryDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("InventoryItemId")]
        public int InventoryItemId { get; set; }

        public DateTime DateOccurred { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("InventoryItemId")]
        public InventoryItemDTO InventoryItemDTO { get; set; }
    }
}
