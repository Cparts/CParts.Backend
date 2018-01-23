using Microsoft.Extensions.DependencyInjection;

namespace CParts.Web
{
    public static class AbstractionsRegistrator
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services;
        }
    }
}