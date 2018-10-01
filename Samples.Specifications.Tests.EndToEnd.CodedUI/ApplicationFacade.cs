using LogoFX.Client.Testing.Contracts;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Samples.Specifications.Tests.EndToEnd
{
    class ApplicationFacade : IApplicationFacade
    {
        public void Start(string startupPath)
        {
            Playback.Initialize();
            ApplicationUnderTest.Launch(startupPath);
        }

        public void Stop()
        {
            Playback.Cleanup();
        }
    }
}
