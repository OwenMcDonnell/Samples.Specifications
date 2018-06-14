using Microsoft.VisualStudio.TestTools.UITesting;
using Samples.Specifications.Tests.Domain;

namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
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
            //Playback.Initialize();
        }
#endif
    }

    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            Playback.Cleanup();
        }
    }
}
