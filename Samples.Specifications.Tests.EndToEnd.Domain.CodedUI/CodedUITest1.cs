﻿using System.IO;
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
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            Playback.Initialize();
            var testDirectory = Directory.GetCurrentDirectory();
            var applicationDirectory =
                Directory
                    .GetParent(Directory.GetParent(Directory.GetParent(testDirectory).FullName).FullName).FullName;
            var applicationPath = Path.Combine(applicationDirectory, "bin", "EndToEndWithFake", "Samples.Specifications.Client.Launcher.exe");
            Directory.SetCurrentDirectory(applicationDirectory);
            var app = ApplicationUnderTest.Launch(applicationPath);
            var topParent = app.TopParent;            

            var controlType = topParent.ControlType;
            var loginWindow = new WpfWindow();
            loginWindow.SearchProperties.Add(new PropertyExpression(UITestControl.PropertyNames.Name, "Login View", PropertyExpressionOperator.Contains));
            loginWindow.Find();
            var children = loginWindow.GetChildren().GetNamesOfControls();
            var auomationId = loginWindow.AutomationId;            
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            Playback.Cleanup();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

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