using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}