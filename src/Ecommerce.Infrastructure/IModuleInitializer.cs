using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrastructure
{
    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }
}
