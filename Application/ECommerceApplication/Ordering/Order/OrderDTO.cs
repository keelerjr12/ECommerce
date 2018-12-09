using System;

namespace ECommerceApplication.Ordering.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public int CustomerId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
    }
}
