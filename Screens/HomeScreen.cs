using Infusion.Specflow.Tests.Template.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Infusion.Specflow.Tests.Template.Screens
{
    public class HomeScreen
    {
        protected AndroidDriver<IWebElement> AppiumDriver;

        public HomeScreen(AndroidDriver<IWebElement> driver)
        {
            AppiumDriver = driver;
        }

        public IWebElement ProgressBar => AppiumDriver.FindElement(By.XPath(AppiumElementLocators.ProgressBarXpath));

        public IWebElement Button(string text)
        {
            return AppiumDriver.FindElement(By.XPath(string.Format(AppiumElementLocators.ButtonTextXPath, text)));
        }

        public IWebElement TextView(string text)
        {
            return AppiumDriver.FindElement(By.XPath(string.Format(AppiumElementLocators.TextViewTextXPath, text)));
        }
    }
}