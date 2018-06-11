using System.IO;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    //[CodedUITest]
    [TestClass]
    public class CodedUITest1
    {        
        [TestMethod]
        public void CodedUITestMethod1()
        {
            Playback.Initialize();
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, "Samples.Specifications.Client.Launcher.exe");
            Directory.SetCurrentDirectory(applicationDirectory);
            var app = ApplicationUnderTest.Launch(applicationPath);            
            var loginWindow = new WpfWindow();
            loginWindow.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name, "Login View", PropertyExpressionOperator.Contains));
            loginWindow.Find();
            var children = loginWindow.GetChildren().GetNamesOfControls();                         
            Playback.Cleanup();
        }        
        

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
