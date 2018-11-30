using System.Collections.Generic;
using ECommerceData.InventoryManagement.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.InventoryManagement.Inventory
{
    [Table("InventoryItem")]
    public class InventoryItemDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Id")]
        public int InventoryId { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        public List<InventoryItemEntryDTO> Entries { get; set; }

        [ForeignKey("InventoryId")]
        public InventoryDTO Inventory { get; set; }

        [ForeignKey("Id")]
        public ProductDTO Product { get; set; }
    }
}