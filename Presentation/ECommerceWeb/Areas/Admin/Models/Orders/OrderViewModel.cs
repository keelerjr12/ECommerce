using System;

namespace ECommerceWeb.Areas.Admin.Models.Orders
{
    public class OrderViewModel
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