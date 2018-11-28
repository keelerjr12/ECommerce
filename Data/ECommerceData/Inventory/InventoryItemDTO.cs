using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Product;

namespace ECommerceData.Inventory
{
    [Table("InventoryItem")]
    internal class InventoryItemDTO
    {
        [Column("InventoryId")]
        public int InventoryId { get; set; }

        [Column("SKU")]
        public string SKU { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Category")]
        public string Category { get; set; }

        public List<InventoryItemEntryDTO> Entries { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        [ForeignKey("InventoryId")]
        public InventoryDTO Inventory { get; set; }

        [ForeignKey("SKU")]
        public ProductDTO Product { get; set; }
    }
}