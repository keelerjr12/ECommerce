using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceData.Order;
using ECommerceDomain.Common;
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

        public OrderCreateCommandHandler(UnitOfWork uow, IOrderRepository orderRepo)
        {
            _uow = uow;
            _orderRepo = orderRepo;
        }

        public async Task<Unit> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            
            var items = new List<Item>();
            /*foreach (var itemDTO in request.Items)
            {

                var product = new Product();
                var item = new Item(product, itemDTO.Quantity);
            }*/
            
            var billing = new Address(request.StreetAddress, request.City, request.State, request.Country,
                request.ZipCode);
            var shipping = new Address(request.StreetAddress, request.City, request.State, request.Country,
                request.ZipCode);

            var order = Order.Create(request.CustomerId, shipping, billing, items);
            
            _orderRepo.Create(order);

            _uow.Save();

            return new Unit();
        }
        
        private readonly UnitOfWork _uow;
        private readonly IOrderRepository _orderRepo;
    }
}
