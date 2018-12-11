using System;
using MediatR;

namespace ECommerceData
{
    public class UnitOfWork
    {
        public UnitOfWork(ECommerceContext eCommerceContext, IMediator mediator)
        {
            _eCommerceContext = eCommerceContext;
            _mediator = mediator;
        }

        public void Save()
        {
            _eCommerceContext.SaveChanges();

            var events = _eCommerceContext.DomainEvents;
            _eCommerceContext.ClearDomainEvents();
      
            foreach (var domainEvent in events)
            {
                Console.WriteLine(domainEvent.ToString());
                _mediator.Publish(domainEvent);
            }
        }

        private readonly ECommerceContext _eCommerceContext;
        private readonly IMediator _mediator;
    }
}
