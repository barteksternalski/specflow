using OpenQA.Selenium;
using specflowPoC.EnvironmentSetup;
using System.Configuration;
using TechTalk.SpecFlow;

namespace specflowPoC
{
    public class BaseSteps
    {
        protected static IWebDriver driver;
        protected RegistrationPage registrationPage;

        [BeforeScenario("UISmoke")]
        public void SetupBrowser()
        {
            driver = WebdriverSetup.InitBrowser(ConfigurationManager.AppSettings.Get("Browser"));
            registrationPage = new RegistrationPage(driver);
        }

        [AfterScenario("UISmoke")]
        public void TearDownBrowser()
        {
            driver.Dispose();
        }
    }
}
