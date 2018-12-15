using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Shopping.Product;

namespace ECommerceData.Inventory.Inventory
{
    [Table("InventoryItem")]
    public class InventoryItemDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        public string Description { get; set; }
        
        public string Category { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        public List<InventoryItemEntryDTO> Entries { get; set; }

        [ForeignKey("Id")]
        public ProductDTO Product { get; set; }
    }
}