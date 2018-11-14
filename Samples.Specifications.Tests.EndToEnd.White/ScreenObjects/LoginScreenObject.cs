using System;
using System.Linq;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Wpf;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Tests.Contracts.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace Samples.Specifications.Tests.EndToEnd.ScreenObjects
{
    internal sealed class LoginScreenObject : ILoginScreenObject
    {
        public void Login()
        {            
            /*var loginScreen = GetLoginScreen();
            var loginButton = loginScreen.Get<Button>("Login_SignIn");            
            loginButton.Click();*/
            var loginScreen = GetLoginScreenTelerik();            
            var loginButton = loginScreen.Find.ByAutomationId("Login_SignIn");
            Task.Delay(1000).Wait();
            loginButton.User.Click();            
        }

        public void SetUsername(string username)
        {            
            var loginScreen = GetLoginScreen();
            for (int i = 0; i < 3; i++)
            {
                var userNameTextBox = loginScreen.Get<TextBox>("Login_UserName");
                userNameTextBox.Enter(username);
                if (userNameTextBox.Text == username)
                {
                    break;
                }
            }            
        }

        public void SetPassword(string password)
        {
            var loginScreen = GetLoginScreen();
            var passwordBox = loginScreen.Get(SearchCriteria.ByAutomationId("Login_Password"));
            passwordBox.Enter(password);
        }

        private Window GetLoginScreen()
        {
            var application = ApplicationContext.Application;
            var loginScreen = application.GetWindowByTitle("Login View");
            if (loginScreen.Visible == false || loginScreen.Enabled == false)
            {
                throw new Exception();
            }
            return loginScreen;
        }

        private WpfWindow GetLoginScreenTelerik()
        {
            WpfWindow loginScreen = null;
            while(loginScreen == null)
            {
                //Yes it's an infinite loop
                var windows = Manager.Current.Applications[0].Windows.ToArray();
                 loginScreen = windows.FirstOrDefault(t => t.Window.Caption == "Login View");
            }            
            return loginScreen;
        }

        public string GetErrorMessage()
        {
            var loginScreen = GetLoginScreen();
            var errorLabel = DelegateExtensions.ExecuteWithResult(() =>
                    loginScreen.Get<Label>(SearchCriteria.ByAutomationId("Login_FailureTextBlock")), r => r.Text,
                new[] {null, string.Empty});
            return errorLabel.Text;
        }
    }
}
