using Ecommerce.Infrastructure.Models;

namespace Ecommerce.Infrastructure.Data
{
    public interface IRepository<T> : IRepositoryWithTypedId<T, long> where T : IEntityWithTypedId<long>
    {
    }
}
