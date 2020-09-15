namespace Functions.IOC
{
    using Microsoft.Extensions.DependencyInjection;

    public class CoreAppModule : Module
    {
        public override void Load(IServiceCollection services)
        {
            services.AddOptions().RegisterFunctionServices();
        }
    }
}
