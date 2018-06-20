using System;
using System.Linq;
using System.Threading;
using LogoFX.Client.Testing.EndToEnd.White;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Samples.Specifications.Tests.Domain.ScreenObjects;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

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

        private Window GetLoginScreen()
        {
            var application = ApplicationContext.Application;
            var loginScreen = application.GetWindowEx("Login View");
            if (loginScreen.Visible == false || loginScreen.Enabled == false)
            {
                throw new Exception();
            }
            return loginScreen;
        }
    }

    public static class ApplicationExtensions
    {
        public static Window GetWindowEx(this Application app, string title)
        {
            if (app.HasExited)
            {
                return null;
            }
            app.WaitWhileBusy();
            Func<Window> getWindow = () =>
            {
                var window = app.GetWindows().SingleOrDefault(x => x.Title == title);
                if (window == null || window.Visible == false || window.Enabled == false)
                {
                    throw new Exception();
                }
                return window;
            };
            return getWindow.ExecuteWithResult(5, TimeSpan.FromMilliseconds(500));
        }
    }

    public static class DelegateExtensions
    {
        public static void Execute(this Action action)
        {
            Execute<Exception>(action, 20, TimeSpan.FromMilliseconds(200));
        }

        public static void Execute<TException>(this Action action)
            where TException : Exception
        {
            Execute<TException>(action, 20, TimeSpan.FromMilliseconds(200));
        }

        public static TResult ExecuteWithResult<TException, TResult>(this Func<TResult> func)
            where TException : Exception
        {
            return ExecuteWithResult<TException, TResult>(func, 20, TimeSpan.FromMilliseconds(200));
        }

        public static TResult ExecuteWithResult<TResult>(this Func<TResult> func)
        {
            return ExecuteWithResult<Exception, TResult>(func, 20, TimeSpan.FromMilliseconds(200));
        }

        public static void Execute<TException>(this Action action, int numberOfRetries, TimeSpan waitingInterval)
            where TException : Exception
        {
            TException lastException = null;
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    action();
                    return;
                }
                catch (TException ex)
                {
                    lastException = ex;
                    Thread.Sleep(waitingInterval);
                }
            }
            if (lastException != null)
            {
                throw lastException;
            }
        }

        public static TResult ExecuteWithResult<TException, TResult>(this Func<TResult> func, int numberOfRetries, TimeSpan waitingInterval)
            where TException : Exception
        {
            TException lastException = null;
            for (int i = 0; i < numberOfRetries; i++)
            {
                try
                {
                    return func();
                }
                catch (TException ex)
                {
                    lastException = ex;
                    Thread.Sleep(waitingInterval);
                }
            }
            if (lastException != null)
            {
                throw lastException;
            }
            return default(TResult);
        }

        public static TResult ExecuteWithResult<TResult>(this Func<TResult> func, int numberOfRetries, TimeSpan waitingInterval)
        {
            return ExecuteWithResult<Exception, TResult>(func, numberOfRetries, waitingInterval);
        }
    }
}
