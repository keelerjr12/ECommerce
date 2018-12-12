using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Inventory.Product;

namespace ECommerceData.Inventory.Inventory
{
    [Table("InventoryItem")]
    public class InventoryItemDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        public List<InventoryItemEntryDTO> Entries { get; set; }

        [ForeignKey("Id")]
        public ProductDTO Product { get; set; }
    }
}