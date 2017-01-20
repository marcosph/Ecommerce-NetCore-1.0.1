using System;
using Ecommerce.Domain.Core.Commands;

namespace Ecommerce.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
