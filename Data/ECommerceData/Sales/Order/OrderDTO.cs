using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceData.Sales.Customer;

namespace ECommerceData.Sales.Order
{
    [Table("Order")]
    public class OrderDTO
    {
        [Column("Id")]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
       
        public int CustomerId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int Zipcode { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerDTO CustomerDTO { get; set; }

        public List<OrderLineDTO> OrderLines { get; set; }
    }
}
