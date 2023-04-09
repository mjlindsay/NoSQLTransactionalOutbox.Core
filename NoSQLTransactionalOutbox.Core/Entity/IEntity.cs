using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQLTransactionalOutbox.Core.Entity
{
    public interface IEntity
    {

        string Id { get; }
    }
}
