using Infusion.Specflow.Tests.Template.Extensions;
using Infusion.Specflow.Tests.Template.TestContext;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Infusion.Specflow.Tests.Template.TestSteps
{
    [Binding]
    internal class AppiumSteps
    {
        private static AndroidDriver<IWebElement> _appiumDriver;
        private readonly ScreensContext _screensContext;

        public AppiumSteps(ScreensContext screensContext)
        {
            _screensContext = screensContext;
            _appiumDriver = ScreensContext.AppiumDriver;
        }

        [Given("I started test app")]
        public void RestartTestApp()
        {
            var packageName = ConfigurationManager.AppSettings.Get("AppAndroidPackageName");
            _appiumDriver.StartActivity(packageName, $"{packageName}.HomeScreenActivity");
        }

        [Given(@"I click on '(.*)'")]
        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string buttonText)
        {
            _screensContext.Home.Button(buttonText).Click();
        }

        [When(@"'(.*)' text is shown on (?:modal|screen)")]
        [Then(@"'(.*)' text is shown on (?:modal|screen)")]
        public void ThenTextIsShownOnModal(string modalText)
        {
            Assert.IsTrue(_screensContext.Home.TextView(modalText).Displayed);
        }

        [Then(@"I wait for '(.*)' modal to disappear")]
        public void ThenIWaitForModalToDisappear(string modalText)
        {
            _screensContext.Home.TextView(modalText).WaitForVisible();
            _screensContext.Home.ProgressBar.WaitForInvisible();
        }
    }
}