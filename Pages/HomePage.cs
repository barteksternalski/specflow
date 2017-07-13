using Infusion.Specflow.Tests.Template.Locators;
using OpenQA.Selenium;

namespace Infusion.Specflow.Tests.Template.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MainMenuButton => Driver.FindElement(By.XPath(WebElementLocators.MenuIconXpath));

        public IWebElement MenuItem(string itemText)
        {
            return Driver.FindElement(By.XPath(string.Format(WebElementLocators.MenuItemXpath, itemText)));
        }
    }
}