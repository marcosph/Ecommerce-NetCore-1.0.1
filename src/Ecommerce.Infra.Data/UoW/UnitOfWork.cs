using Ecommerce.Domain.Core.Commands;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infra.Data.Context;

namespace Ecommerce.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EquinoxContext _context;

        public UnitOfWork(EquinoxContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
