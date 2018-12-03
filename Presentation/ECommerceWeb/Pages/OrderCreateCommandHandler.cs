using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceData.Order;
using ECommerceDomain.Sales.Cart;
using ECommerceDomain.Sales.Customer;
using ECommerceDomain.Sales.Order;
using ECommerceDomain.Sales.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Pages
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand>
    {

        public OrderCreateCommandHandler(ECommerceContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.CustomerId, request.FirstName, request.MiddleName,
                request.LastName, request.StreetAddress, request.City, request.State, request.Country,
                request.ZipCode);
            
            var items = new List<Item>();
            foreach (var itemDTO in request.Items)
            {

                var product = new Product();
                var item = new Item(product, itemDTO.Quantity);
            }

            var order = new Order(DateTime.Now, customer, items);

            var orderDTO = new OrderDTO();
            //{

            //}

            _db.Orders.Add(orderDTO);
            */
            return new Unit();
        }
        
        private readonly ECommerceContext _db;
    }
}
