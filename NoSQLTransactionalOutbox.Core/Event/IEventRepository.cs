using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTransactionalOutbox.Core.Event
{
    public interface IEventRepository<T> where T : IEvent
    {
        public void Create(T domainEvent);
    }
}
