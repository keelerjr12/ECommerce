using System;
using System.Collections.Generic;

namespace ECommerceApplication.Ordering.Order
{
    public class OrderQueryResult
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }
        public int CustomerId { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }

        public List<OrderLineDTO> OrderLines { get; set; }
    }
}