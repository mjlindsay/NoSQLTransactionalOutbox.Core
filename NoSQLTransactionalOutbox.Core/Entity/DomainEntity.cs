using Newtonsoft.Json;
using NoSQLTransactionalOutbox.Core.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTransactionalOutbox.Core.Entity
{
    public abstract class DomainEntity : IEntity, IEventEmitter<IEvent>
    {
        [JsonProperty]
        public string Id { get; protected init; } = string.Empty;

        [JsonProperty]
        public DateTime CreatedAt { get; protected set; }

        [JsonProperty]
        public DateTime? ModifiedAt { get; protected set; }

        [JsonProperty]
        public DateTime? DeletedAt { get; protected set; }

        [JsonProperty]
        public bool IsDeleted { get; protected set; }

        [JsonIgnore]
        protected bool IsNew { get; init; }


        private readonly List<IEvent> _events = new List<IEvent>();
        [JsonIgnore]
        public IReadOnlyList<IEvent> DomainEvents => _events.AsReadOnly();

        public virtual void AddEvent(IEvent domainEvent) {
            var i = _events.FindIndex(0, eventInCollection => eventInCollection.Action == domainEvent.Action);
            if (i < 0)
                _events.Add(domainEvent);
            else {
                _events.RemoveAt(i);
                _events.Insert(i, domainEvent);
            }
        }

        public virtual void RemoveEvent(IEvent domainEvent) {
            _events.Remove(domainEvent);
        }

        public virtual void RemoveAllEvents() {
            _events.Clear();
        }
    }
}
