using Functions.IOC.IOC.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Functions.IOC
{
    public class Module : IModule
    {
        public virtual void Load(IServiceCollection services)
        {
            return;
        }
    }
}
