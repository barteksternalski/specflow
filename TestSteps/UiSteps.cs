using Infusion.Specflow.Tests.Template.TestContext;
using Infusion.Specflow.Tests.Template.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Infusion.Specflow.Tests.Template.TestSteps
{
    [Binding]
    public class UiSteps
    {
        private static IWebDriver _driver;
        private readonly PagesContext _pagesContext;

        public UiSteps(PagesContext pagesContext)
        {
            _pagesContext = pagesContext;
            _driver = PagesContext.Driver;
        }

        [Given(@"I open home page")]
        public void OpenHomePage()
        {
            WebDriverHelper.OpenUrl();
            Assert.AreEqual(ConfigurationManager.AppSettings.Get("ServerAddress"), _driver.Url);
        }

        [When(@"I click on menu button")]
        public void ClickOnMenuButton()
        {
            _pagesContext.Home.MainMenuButton.Click();
        }

        [Then(@"list of menu items is displayed")]
        public void MenuItemsAreDisplayed(Table table)
        {
            foreach (var tableRow in table.Rows)
            {
                tableRow.TryGetValue("menu items", out string itemText);
                Assert.IsTrue(_pagesContext.Home.MenuItem(itemText).Displayed, $"Menu item \"{itemText}\" is not displayed");
            }
        }
    }
}