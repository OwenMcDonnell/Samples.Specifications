﻿using System.Reflection;
using LogoFX.Client.Testing.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterAutomagically(
                    Assembly.LoadFrom("Samples.Specifications.Tests.Contracts.dll"),
                    Assembly.GetExecutingAssembly())                
                .AddSingleton<IApplicationFacade, ApplicationFacade>();
        }
    }
}
