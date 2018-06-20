using System.Diagnostics;
using System.Linq;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;
using Microsoft.VisualStudio.TestTools.UITesting;
using TestStack.White;

namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
{
    class ApplicationFacade : IApplicationFacade
    {
        public void Start(string startupPath)
        {
            Playback.Initialize();
            ApplicationUnderTest.Launch(startupPath);
            var process = Process.GetProcesses().FirstOrDefault(t => t.ProcessName.Contains("Samples"));
            ApplicationContext.Application = Application.Attach(process);
            ApplicationContext.Application.WaitWhileBusy();
        }

        public void Stop()
        {
            Playback.Cleanup();
            ApplicationContext.Application?.Dispose();
        }
    }
}
