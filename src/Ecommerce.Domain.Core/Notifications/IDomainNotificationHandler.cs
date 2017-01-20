using System.Collections.Generic;
using Ecommerce.Domain.Core.Events;

namespace Ecommerce.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}