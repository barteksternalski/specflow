using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace specflowPoC
{
    public class BaseSteps
    {
        protected IWebDriver driver;
        protected RegistrationPage registrationPage;

        [BeforeScenario]
        public void setupBrowser()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            registrationPage = new RegistrationPage(driver);
        }

        [AfterScenario]
        public void tearDownBrowser()
        {
            driver.Dispose();
        }
    }
}
