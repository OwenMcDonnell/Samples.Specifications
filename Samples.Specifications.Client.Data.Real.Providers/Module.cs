﻿using System.Reflection;
using JetBrains.Annotations;
using RestSharp;
using Samples.Specifications.Client.Data.Real.Providers.Properties;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .RegisterAutomagically(
                    Assembly.LoadFrom("Samples.Client.Data.Contracts.Providers.dll"),
                    Assembly.GetExecutingAssembly())
                .AddSingleton(() => new RestClient(Settings.Default.ServerEndpoint));
        }             
    }
}
