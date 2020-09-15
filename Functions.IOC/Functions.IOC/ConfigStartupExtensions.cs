namespace Functions.IOC
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigStartupExtensions
    {
        public static IServiceCollection RegisterConfigServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
