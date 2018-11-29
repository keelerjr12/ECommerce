using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.InventoryManagement.Inventory
{
    [Table("InventoryItemEntry")]
    public class InventoryItemEntryDTO
    {
        public int Id { get; set; }

        [Column("InventoryId")]
        public int InventoryId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        public DateTime DateOccurred { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("InventoryId")]
        public ECommerceDomain.InventoryManagement.Inventory.Inventory Inventory { get; set; }

        [ForeignKey("ProductId")]
       public  ECommerceDomain.InventoryManagement.Product.Product Product { get; set; }
    }
}
