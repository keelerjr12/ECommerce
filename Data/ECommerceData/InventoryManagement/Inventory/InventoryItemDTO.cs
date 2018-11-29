using ECommerceData.InventoryManagement.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.InventoryManagement.Inventory
{
    [Table("InventoryItem")]
    public class InventoryItemDTO
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        public List<InventoryItemEntryDTO> Entries { get; set; }

        [ForeignKey("Id")]
        public ProductDTO Product { get; set; }
    }
}