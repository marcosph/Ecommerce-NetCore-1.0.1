using System;
using System.Collections.Generic;
using Ecommerce.Domain.Core.Events;

namespace Ecommerce.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}