using System;
using System.Collections.Generic;
using ECommerceWeb.Areas.Sales.Pages;
using MediatR;

namespace ECommerceWeb
{
    public class OrderCreateCommand : IRequest
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }

        public List<CartItemModel> Items { get; set; }
    }
}