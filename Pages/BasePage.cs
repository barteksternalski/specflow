using OpenQA.Selenium;

namespace Infusion.Specflow.Tests.Template.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}