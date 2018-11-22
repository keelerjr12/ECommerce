using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Inventory
{
    [Table("InventoryProduct")]
    internal class InventoryProductDTO
    {
        [Key]
        public string SKU { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
