using AP_TestAutomationFramework.lib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AP_TestAutomationFramework.tests
{
    public class Tests
    {
        private AP_Website<FirefoxDriver> AP_Website = new();

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickTheSIgninButton_ThenIShouldLandOnTheSignInPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            Thread.Sleep(5000);
            AP_Website.AP_HomePage.VisitSignInPage();
            Thread.Sleep(5000);
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}