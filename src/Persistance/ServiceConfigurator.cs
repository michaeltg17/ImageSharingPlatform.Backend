using Microsoft.Extensions.DependencyInjection;

namespace Persistance
{
    public static class ServiceConfigurator
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<DbContext>();

            return services;
        }
    }
}
