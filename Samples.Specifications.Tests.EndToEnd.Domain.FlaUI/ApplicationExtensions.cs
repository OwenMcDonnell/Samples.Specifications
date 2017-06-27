using System;
using System.Linq;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace Samples.Specifications.Tests.EndToEnd.Domain
{
    public static class ApplicationExtensions
    {
        public static Window GetWindowEx(this Application app, string title)
        {
            //if (app.HasExited)
            //{
            //    return null;
            //}
            app.WaitWhileBusy();
            Func<Window> getWindow = () =>
            {
                using (var automation = new UIA3Automation())
                {                    
                    var window = app.GetAllTopLevelWindows(automation).SingleOrDefault(x => x.Title == title);
                    if (window == null ||
                        //window.Visible == false ||
                        window.Properties.IsEnabled == false)
                    {
                        throw new Exception();
                    }
                    return window;

                }
            };
            return getWindow.ExecuteWithResult(5, TimeSpan.FromMilliseconds(500));
        }
    }
}
