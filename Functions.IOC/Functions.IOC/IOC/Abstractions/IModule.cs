namespace Functions.IOC.IOC.Abstractions
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IModule
    {
        void Load(IServiceCollection services);
    }
}
