using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Shipping
{
    [Table("ShippingDistance")]
    public class ShippingDistanceDTO
    {
        [Key]
        public string State { get; set; }
    }
}
