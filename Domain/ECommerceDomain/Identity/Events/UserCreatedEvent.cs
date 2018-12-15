using System;
using ECommerceDomain.Common;

namespace ECommerceDomain.Identity.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public Guid Id { get; }

        public UserCreatedEvent(Guid id)
        {
            Id = id;
        }
    }
}
