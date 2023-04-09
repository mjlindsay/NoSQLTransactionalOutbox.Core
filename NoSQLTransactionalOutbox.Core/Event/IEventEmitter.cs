using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTransactionalOutbox.Core.Event
{
    public interface IEventEmitter<T> where T : IEvent
    {
        public void AddEvent(T domainEvent);

        public void RemoveEvent(T domainEvent);

        public void RemoveAllEvents();

        public IReadOnlyList<T> DomainEvents { get; }
    }
}
