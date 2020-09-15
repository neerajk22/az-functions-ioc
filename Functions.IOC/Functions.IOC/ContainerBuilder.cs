﻿using Functions.IOC.IOC.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Functions.IOC
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly IServiceCollection _services;

        public ContainerBuilder()
        {
            this._services = new ServiceCollection();
        }

        public IContainerBuilder RegisterModule(IModule module = null)
        {
            if (module == null)
            {
                module = new Module();
            }

            module.Load(this._services);

            return this;
        }

        public IServiceProvider Build()
        {
            var provider = this._services.BuildServiceProvider();

            return provider;
        }
    }
}
