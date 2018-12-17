using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using ECommerceDomain.Ordering.Customer;
using ECommerceDomain.Ordering.Order;
using ECommerceDomain.Shopping.Cart;
using ECommerceDomain.Shopping.Common;
using MediatR;

namespace ECommerceApplication.Ordering.Order.Commands
{
    public class CreateOrderCommand
    {
        public class Request : IRequest
        {
            public Guid CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Request>
        {
            public Handler(UnitOfWork uow, ICustomerRepository customerRepo, ICartRepository cartRepo, IOrderRepository orderRepo)
            {
                _uow = uow;
                _customerRepo = customerRepo;
                _cartRepo = cartRepo;
                _orderRepo = orderRepo;
            }

            public Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var customer = _customerRepo.GetById(request.CustomerId);
                var cart = _cartRepo.FindById(request.CustomerId);
                var cartItems = cart.Items;

                var items = new List<LineItem>();
                foreach (var item in cartItems)
                {
                    //TODO: Finish!
                    //items.Add(new LineItem(item.SKU, item.Quantity.Value, item.Price));
                }

                var order = customer.PlaceOrder(items);

                cart.Empty();

                _orderRepo.Save(order);
                _cartRepo.Update(cart);

                _uow.Save();

                return Unit.Task;
            }

            private readonly UnitOfWork _uow;
            private readonly ICustomerRepository _customerRepo;
            private readonly ICartRepository _cartRepo;
            private readonly IOrderRepository _orderRepo;
        }
    }
}
