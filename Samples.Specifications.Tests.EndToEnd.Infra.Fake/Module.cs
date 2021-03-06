﻿using Attest.Testing.Contracts;
using Attest.Testing.Core;
using Attest.Testing.Core.FakeData;
using Attest.Testing.EndToEnd;
using JetBrains.Annotations;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Fake
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {                
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IStartApplicationService, StartApplicationService.WithFakeProviders>()
            .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>()
            .AddSingleton<ISetupService, SetupServiceBase>()
            .RegisterBuilders();
    }
}
