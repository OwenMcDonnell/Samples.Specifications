using ArtOfTest.WebAii.Core;
using Attest.Testing.Contracts;
using LogoFX.Client.Testing.Contracts;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Samples.Specifications.Tests.EndToEnd
{
    class StartClientApplicationService : IStartClientApplicationService
    {
        private readonly IStartLocalApplicationService _startLocalApplicationService;
        private readonly IApplicationPathInfo _applicationPathInfo;

        public StartClientApplicationService(
            IStartLocalApplicationService startLocalApplicationService,
            IApplicationPathInfo applicationPathInfo)
        {
            _startLocalApplicationService = startLocalApplicationService;
            _applicationPathInfo = applicationPathInfo;
        }

        public void StartApplication()
        {
            _startLocalApplicationService.Start();
            var applicationPath = Path.Combine(Directory.GetCurrentDirectory(), _applicationPathInfo.RelativePath);
            StartWebAii(applicationPath);
        }

        private static void StartWebAii(string applicationPath)
        {
            Settings settings = new Settings
            {
                ClientReadyTimeout = 100,
                Wpf = {DefaultApplicationPath = applicationPath}
            };
            Manager manager = new Manager(settings);

            var process = Process.GetProcesses().FirstOrDefault(t => t.ProcessName.StartsWith("Samples"));
            if (process != null)
            {
                manager.Start();

                manager.ConnectToApplication(process);
            }
        }
    }
}
