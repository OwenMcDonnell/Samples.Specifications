﻿using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Launcher.Shared;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;
using Solid.Practices.Composition;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public class TestBootstrapper : TestBootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<IShellViewModel>
    {
        public TestBootstrapper() :
            base(new ExtendedSimpleContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false,
                ReuseCompositionInformation = true
            })
        {
            this.UseResolver().UseShared().Initialize();
        }

        public override CompositionOptions CompositionOptions => new CompositionOptions {Prefixes = Consts.Prefixes};
    }
}