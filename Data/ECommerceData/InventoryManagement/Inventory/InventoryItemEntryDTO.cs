using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.InventoryManagement.Inventory
{
    [Table("InventoryItemEntry")]
    public class InventoryItemEntryDTO
    {
        public Guid Id { get; set; }

        public int InventoryId { get; set; }

        public string SKU { get; set; }

        public DateTime DateOccurred { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        //[ForeignKey("InventoryId")]
       //public ECommerceDomain.Inventory.Inventory Inventory { get; set; }

       // [ForeignKey("SKU")]
      //  public ECommerceDomain.Product.Product Product { get; set; }
    }
}
