﻿using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    public sealed class LoginStepsAdapter
    {
        [When(@"I set the username to ""(.*)""")]
        public void WhenISetTheUsernameTo(string username)
        {
            LoginSteps.WhenISetTheUsernameTo(username);
        }

        [When(@"I log in to the system")]
        public void WhenILogInToTheSystem()
        {
            LoginSteps.WhenILogInToTheSystem();
        }

        [Then(@"the login screen is displayed")]
        public void ThenTheLoginScreenIsDisplayed()
        {
            LoginSteps.ThenTheLoginScreenIsDisplayed();            
        }

        [Then(@"Application navigates to the main screen")]
        public void ThenApplicationNavigatesToTheMainScreen()
        {
            //for readability reasons
        }
    }
}