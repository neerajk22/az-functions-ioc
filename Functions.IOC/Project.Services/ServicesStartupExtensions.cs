using Microsoft.Extensions.DependencyInjection;

namespace Project.Services
{
    public static class ServicesStartupExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Services            
            services.AddScoped<ISampleService, SampleService>();
            #endregion
            return services;
        }
    }
}
