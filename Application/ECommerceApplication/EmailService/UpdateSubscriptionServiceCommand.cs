using ECommerceData;
using ECommerceDomain.Ordering.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerceApplication.EmailService
{
    public class UpdateSubscriptionServiceCommand
    {
        public class Request : IRequest
        {
            public Guid CustomerId { get; }

            public bool IsSubscribed { get; }

            public Request(Guid customerId, bool isSubscribed)
            {
                CustomerId = customerId;
                IsSubscribed = isSubscribed;
            }
        }

        public class Handler : IRequestHandler<Request>
        {
            public Handler(UnitOfWork uow, ICustomerRepository customerRepo)
            {
                _uow = uow;
                _customerRepo = customerRepo;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var customer = _customerRepo.GetById(request.CustomerId);

                customer.UpdateSubscription(request.IsSubscribed);

                _customerRepo.Update(customer);

                _uow.Save();

                return Unit.Value;
            }

            private readonly UnitOfWork _uow;
            private readonly ICustomerRepository _customerRepo;
        }
    }
}
