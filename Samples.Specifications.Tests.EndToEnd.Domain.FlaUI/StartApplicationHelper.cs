using FlaUI.Core;
using LogoFX.Client.Testing.Contracts;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    public class StartApplicationHelper : IStartApplicationHelper
    {
        /// <summary>Starts the application.</summary>
        /// <param name="startupPath">The startup path.</param>
        public void StartApplication(string startupPath)
        {
            ApplicationContext.Application = Application.Launch(startupPath);
            ApplicationContext.Application.WaitWhileBusy();
        }
    }
}