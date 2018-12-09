using System.ComponentModel.DataAnnotations;

namespace ECommerceWeb.Areas.Authentication.Models
{
    public class Credentials
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
