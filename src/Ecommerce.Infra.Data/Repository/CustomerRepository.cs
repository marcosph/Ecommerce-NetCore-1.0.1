using System.Linq;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Models;
using Ecommerce.Infra.Data.Context;

namespace Ecommerce.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>,  ICustomerRepository
    {
        public CustomerRepository(EquinoxContext context)
            :base(context)
        {

        }       

        public Customer GetByEmail(string email)
        {
            return Find(c => c.Email == email).FirstOrDefault();
        }
    }
}
