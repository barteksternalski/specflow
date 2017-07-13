using Infusion.Specflow.Tests.Template.Screens;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Infusion.Specflow.Tests.Template.TestContext
{
    public class ScreensContext
    {
        public static AndroidDriver<IWebElement> AppiumDriver { get; set; }
        public HomeScreen Home { get; set; }

        public ScreensContext()
        {
            Home = new HomeScreen(AppiumDriver);
        }
    }
}