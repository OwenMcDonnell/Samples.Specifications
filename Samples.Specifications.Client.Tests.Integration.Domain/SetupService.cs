﻿using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Client.Tests.Integration.Domain
{
    class SetupService : ISetupService
    {
#if REAL
        private readonly ISetupHelper _setupHelper;

        public SetupService(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void Setup()
        {
            _setupHelper.Initialize();
        }
#endif

#if FAKE        
        public void Setup()
        {            
        }
#endif
    }

    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            
        }
    }
}