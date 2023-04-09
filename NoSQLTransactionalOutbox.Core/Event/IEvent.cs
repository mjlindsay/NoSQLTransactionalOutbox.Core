using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTransactionalOutbox.Core.Event
{
    public interface IEvent : INotification
    {
        public string Id { get; }

        public string Action { get; }
    }
}
