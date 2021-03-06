﻿using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    internal sealed class LoginStepsAdapter
    {
        private LoginSteps LoginSteps { get; set; }

        public LoginStepsAdapter(LoginSteps loginSteps)
        {
            LoginSteps = loginSteps;
        }

        [When(@"I set the username to '(.*)'")]
        public void WhenISetTheUsernameTo(string username)
        {
            LoginSteps.WhenISetTheUsernameTo(username);
        }

        [When(@"I log in to the system")]
        public void WhenILogInToTheSystem()
        {
            LoginSteps.WhenILogInToTheSystem();            
        }

        [When(@"I set the password to '(.*)'")]
        public void WhenISetThePasswordTo(string password)
        {
            LoginSteps.WhenISetThePasswordTo(password);
        }

        [Then(@"the login screen is displayed")]
        public void ThenTheLoginScreenIsDisplayed()
        {
            LoginSteps.ThenTheLoginScreenIsDisplayed();            
        }        

        [Then(@"Login error message is displayed with the following text '(.*)'")]
        public void ThenLoginErrorMessageIsDisplayedWithTheFollowingText(string errorMessage)
        {
            LoginSteps.ThenLoginErrorMessageIsDisplayedWithTheFollowingText(errorMessage);
        }
    }
}
