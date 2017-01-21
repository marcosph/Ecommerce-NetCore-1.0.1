using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
