using System;

namespace Functions.IOC.IOC.Abstractions
{
    public interface IContainerBuilder
    {
        IContainerBuilder RegisterModule(IModule module = null);

        IServiceProvider Build();
    }
}
