using System.Collections.Generic;
using System.Linq;

namespace ECommerceDomain.Common
{
    public class AggregateRoot
    {
        public IReadOnlyList<IDomainEvent> DomainEvents => _events.ToList();

        protected void AddEvent(IDomainEvent domainEvent)
        {
            _events.Add(domainEvent);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();
    }
}
