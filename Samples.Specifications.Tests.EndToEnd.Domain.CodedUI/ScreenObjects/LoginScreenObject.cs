using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.EndToEnd.Domain.CodedUI.ScreenObjects
{
    class LoginScreenObject : ILoginScreenObject
    {
        public void Login()
        {
            var loginButton = new WpfButton(GetLoginWindow());
            loginButton.SearchProperties.Add(new PropertyExpression(WpfControl.PropertyNames.AutomationId, "Login_SignIn"));
            loginButton.Find();
            loginButton.WaitForControlReady();            
            Mouse.Click(loginButton);
        }

        public void SetUsername(string username)
        {
            var usernameEdit = new WpfEdit(GetLoginWindow());
            usernameEdit.SearchProperties.Add(new PropertyExpression(WpfControl.PropertyNames.AutomationId, "Login_UserName"));
            usernameEdit.Find();
            usernameEdit.WaitForControlReady();
            usernameEdit.Text = string.Empty;
            Keyboard.SendKeys(usernameEdit, username);            
        }

        public void SetPassword(string password)
        {
            var passwordEdit = new WpfEdit(GetLoginWindow());
            passwordEdit.SearchProperties.Add(new PropertyExpression(WpfControl.PropertyNames.AutomationId, "Login_Password"));
            passwordEdit.Find();
            passwordEdit.WaitForControlReady();
            Keyboard.SendKeys(passwordEdit, password);
        }

        public string GetErrorMessage()
        {
            throw new System.NotImplementedException();
        }

        private WpfWindow GetLoginWindow()
        {
            var loginWindow = new WpfWindow();
            loginWindow.SearchProperties.Add(new PropertyExpression(WpfControl.PropertyNames.Name, "Login View", PropertyExpressionOperator.Contains));
            loginWindow.Find();
            return loginWindow;
        }
    }
}
