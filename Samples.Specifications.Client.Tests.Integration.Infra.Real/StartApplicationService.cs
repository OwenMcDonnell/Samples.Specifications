﻿using LogoFX.Client.Testing.Integration;
using LogoFX.Client.Testing.Integration.SpecFlow;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Samples.Specifications.Client.Tests.Integration.Infra.Core;
using Samples.Specifications.Client.Tests.Integration.Infra.Shared;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Real
{
    class StartApplicationService : StartApplicationServiceBase
    {
        private readonly StructureHelper _structureHelper;

        public StartApplicationService(StructureHelper structureHelper)
        {
            _structureHelper = structureHelper;
        }

        protected override void Setup()
        {
            base.Setup();            
            //TODO: Strictly speaking this is not an appropriate place
            //for root object initialization - need to rethink the whole initialization process
            //for integration tests which MUST initialize their root object after the arrange step
            var bootstrapperBridge = new BootstrapperBridge();
            bootstrapperBridge.InitializeRootObject();            
            SetupCore();
        }

        private static void SetupCore()
        {
            LogoFX.Client.Testing.Shared.TestHelper.Setup();
        }

        protected override void OnStart(object rootObject)
        {
            base.OnStart(rootObject);
            RootObjectHelper.InitializeRootObject(_structureHelper, rootObject);
        }

        class BootstrapperBridge : IntegrationTestsBase<ShellViewModel, TestBootstrapper.SpecBased>.
            WithExplicitRootObjectCreation
        {

        }
    }
}