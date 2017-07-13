using Infusion.Specflow.Tests.Template.TestContext;
using Infusion.Specflow.Tests.Template.Utilities;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Infusion.Specflow.Tests.Template.TestSteps
{
    [Binding]
    public class SetupSteps
    {
        [BeforeTestRun]
        public static void Setup()
        {
            if (bool.Parse(ConfigurationManager.AppSettings.Get("LocalEnvironment")))
            {
                // Add operations done when running locally
                // For example prepare test data in database
            }
        }

        [BeforeScenario("UI")]
        public static void BeforeScenarioUi()
        {
            // UI specific code here, we're reusing browser here
            if (PagesContext.Driver != null) return;
            WebDriverHelper.InitBrowser();
            //WebDriverHelper.Login();
            WebDriverHelper.OpenUrl();
            PagesContext.Driver = WebDriverHelper.Driver;
        }

        [BeforeFeature("AVD")]
        public static void BeforeScenarioAvd()
        {
            if (ScreensContext.AppiumDriver != null) return;
            AppiumHelper.InitEmulator(ConfigurationManager.AppSettings.Get("EmulatorName"));
            ScreensContext.AppiumDriver = AppiumHelper.Driver;
        }

        [AfterTestRun]
        public static void TearDown()
        {
            if (PagesContext.Driver != null) WebDriverHelper.CloseAllDrivers();
            if (ScreensContext.AppiumDriver != null) AppiumHelper.CloseEmulator();
            if (bool.Parse(ConfigurationManager.AppSettings.Get("LocalEnvironment")))
            {
                // Add operations done when running locally
                // For example cleaning test data in database
            }
        }
    }
}