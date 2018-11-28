using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Customer
{
    [Table("Customer")]
    internal class CustomerDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress{ get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }
    }
}
