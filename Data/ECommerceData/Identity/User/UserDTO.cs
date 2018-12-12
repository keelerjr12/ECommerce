using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Identity.User
{
    [Table("User")]
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string UserType { get; set; }
    }
}