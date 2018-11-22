using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Inventory
{
    [Table("InventoryItem")]
    internal class InventoryItemDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("InventoryId")]
        public int InventoryId { get; set; }

        [Column("ProductSKU")]
        public string ProductSKU { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Category")]
        public string Category { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        [Column("UnitCost")]
        public decimal UnitCost { get; set; }

        [ForeignKey("InventoryId")]
        public InventoryDTO Inventory { get; set; }
    }
}