using System;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.InventoryManagement.Inventory;

namespace ECommerceData.InventoryManagement.Product
{
    [Table("InventoryProduct")]
    public class ProductDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        public int InventoryId { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [ForeignKey("Id")]
        public ECommerceData.Product.ProductDTO Product { get; set; }

        [ForeignKey("InventoryId")]
        public InventoryDTO Inventory { get; set; }
    }
}
