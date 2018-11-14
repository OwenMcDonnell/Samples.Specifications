using ArtOfTest.WebAii.Core;
using Attest.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;

namespace Samples.Specifications.Tests.EndToEnd
{
    class TeardownService : ITeardownService
    {
        public void Teardown()
        {
            ApplicationContext.Application?.Close();
            ApplicationContext.Application?.Dispose();
            Manager.Current.Dispose();
        }
    }
}
