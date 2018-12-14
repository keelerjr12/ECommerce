using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Areas.Account.Models
{
    public class NewProductViewModel
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
