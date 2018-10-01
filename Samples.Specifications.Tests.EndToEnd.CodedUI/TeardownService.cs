using Attest.Testing.Contracts;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Samples.Specifications.Tests.EndToEnd
{
    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            Playback.Cleanup();
        }
    }
}
