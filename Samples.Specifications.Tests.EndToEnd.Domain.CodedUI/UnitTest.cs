using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Xunit;


namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
{
    public class UnitTest : IDisposable
    {
        public UnitTest()
        {
            Playback.Initialize();
        }

        [Fact]
        public void TestMethod()
        {
            
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory =
                Directory
                    .GetParent(Directory.GetParent(Directory.GetParent(testDirectory).FullName).FullName).FullName;
            var applicationPath = Path.Combine(applicationDirectory, "bin", "EndToEndWithFake", "Samples.Specifications.Client.Launcher.exe");
            Directory.SetCurrentDirectory(applicationDirectory);
            var app = ApplicationUnderTest.Launch(applicationPath);            
            var loginWindow = new WpfWindow();
            loginWindow.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name, "Login View", PropertyExpressionOperator.Contains));
            loginWindow.Find();
            var children = loginWindow.GetChildren().GetNamesOfControls();                                    
        }

        public void Dispose()
        {
            Playback.Cleanup();
        }
    }
}
