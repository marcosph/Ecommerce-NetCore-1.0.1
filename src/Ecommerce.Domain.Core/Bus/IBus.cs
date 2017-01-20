using Ecommerce.Domain.Core.Commands;
using Ecommerce.Domain.Core.Events;

namespace Ecommerce.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}