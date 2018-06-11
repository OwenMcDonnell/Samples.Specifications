using System.Reflection;
using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Tests.Domain;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterAutomagically(
                Assembly.LoadFrom("Samples.Specifications.Tests.Domain.dll"),
                    Assembly.GetExecutingAssembly())
                .AddSingleton<IExecutableContainer, ExecutableContainer>()
                .AddSingleton<IApplicationFacade, ApplicationFacade>();
        }
    }
}
