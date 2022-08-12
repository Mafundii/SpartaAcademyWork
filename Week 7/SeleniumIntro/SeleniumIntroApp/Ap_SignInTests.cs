namespace SeleniumIntroApp
{
    public class Tests
    {
        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickSIgnIn_ThenILandOnSignInPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

                IWebElement signInLink = driver.FindElement(By.LinkText("Sign in"));
                signInLink.Click();

                Thread.Sleep(5000);

                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }
        }

        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterA4DigitPassword_WhenIClickSIgnInButton_ThenIGetErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                Thread.Sleep(5000);
                IWebElement emailField = driver.FindElement(By.Id("email"));
                IWebElement passwordField = driver.FindElement(By.Id("passwd"));
                emailField.SendKeys("maks@hadys.com");
                passwordField.SendKeys("four");
                passwordField.SendKeys(Keys.Enter);
                IWebElement alert = driver.FindElement(By.ClassName("alert"));
                Assert.That(alert.Text, Does.Contain("Invalid password"));
            }
        }

        [Category("Welcome to the Internet Tests")]
        [Test]
        public void GivenIAmOnTheRedirectPage_AndIPressHere_ThenIAmTakenToTheStatusCodesPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/redirector");
                Thread.Sleep(5000);
                IWebElement hereLink = driver.FindElement(By.Id("redirect"));
                hereLink.Click();
                Thread.Sleep(5000);
                Assert.That(driver.Url, Is.EqualTo("http://the-internet.herokuapp.com/status_codes"));
            }
        }

        [Test]
        public void GivenIAmOnTheLoginPage_AndIDontInputAnyValues_ThenIGetAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
                Thread.Sleep(5000);
                IWebElement usernameField = driver.FindElement(By.Id("username"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                usernameField.SendKeys("");
                passwordField.SendKeys("");
                IWebElement loginButton = driver.FindElement(By.ClassName("radius"));
                loginButton.Click();
                Thread.Sleep(5000);
                IWebElement alert = driver.FindElement(By.Id("flash"));
                Assert.That(alert.Text, Does.Contain("Your username is invalid"));
            }
        }

        [Test]
        public void GivenIAmOnTheLoginPage_AndIInputValidValues_ThenIAmTakenToASecureArea()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
                Thread.Sleep(5000);
                IWebElement usernameField = driver.FindElement(By.Id("username"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                usernameField.SendKeys("tomsmith");
                passwordField.SendKeys("SuperSecretPassword!");
                IWebElement loginButton = driver.FindElement(By.CssSelector(".fa"));
                loginButton.Click();
                Thread.Sleep(5000);
                IWebElement alert = driver.FindElement(By.Id("flash"));
                Assert.That(driver.Url, Is.EqualTo("http://the-internet.herokuapp.com/secure"));
                Assert.That(alert.Text, Does.Contain("You logged into a secure area"));
            }
        }
    }
}