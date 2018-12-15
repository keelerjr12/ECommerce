﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceData.Ordering.Customer
{
    [Table("Customer")]
    public class CustomerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Street{ get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}
