﻿using ECommerceDomain.Sales.Customer;

namespace ECommerceWeb.Areas.Sales
{
    public class CustomerViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
    }
}
