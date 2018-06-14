using LogoFX.Client.Testing.Contracts;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
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
