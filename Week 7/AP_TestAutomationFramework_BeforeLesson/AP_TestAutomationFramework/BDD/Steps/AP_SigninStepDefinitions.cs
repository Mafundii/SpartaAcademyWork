using System;
using TechTalk.SpecFlow;
using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using AP_TestAutomationFramework.Utilities;

namespace AP_TestAutomationFramework.BDD.Steps
{
    [Binding]
    public class AP_SigninStepDefinitions
    {
        public AP_Website<ChromeDriver> AP_Website { get; } = new AP_Website<ChromeDriver>();
        private Credentials _credentials;

        [Given(@"I am on the signin page")]
        public void GivenIAmOnTheSigninPage()
        {
            AP_Website.AP_SigninPage.VisitSignInPage();
        }

        [Given(@"I have the following credentials:")]
        public void GivenIHaveTheFollowingCredentials(Table table)
        {
            Credentials = _credentials;
        }

        [When(@"enter these credentials")]
        public void WhenEnterTheseCredentials()
        {
            throw new PendingStepException();
        }


        [Given(@"I have entered the email ""([^""]*)""")]
        public void GivenIHaveEnteredTheEmail(string email)
        {
            AP_Website.AP_SigninPage.InputEmailLogin(email);
        }

        [Given(@"I have entered the password ""([^""]*)""")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            AP_Website.AP_SigninPage.InputPasswordLogin(password);
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_SigninPage.ClickSignin();
        }

        [When(@"I click the forgot your password link")]
        public void WhenIClickTheForgotYourPasswordLink()
        {
            AP_Website.AP_SigninPage.ClickForgotPasswordLink();
        }

        [Then(@"I will go to a form to reset my password")]
        public void ThenIWillGoToAFormToResetMyPassword()
        {
            Assert.That(AP_Website.GetPageTitle(), Is.EqualTo("Forgot your password - My Store").IgnoreCase);
        }

        [Then(@"I should see an alert containing the error message ""([^""]*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string expected)
        {
            Assert.That(AP_Website.AP_SigninPage.GetAlertTextSignin(), Does.Contain(expected));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
        }

    }
}
