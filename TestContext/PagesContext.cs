using Infusion.Specflow.Tests.Template.Pages;
using OpenQA.Selenium;

namespace Infusion.Specflow.Tests.Template.TestContext
{
    public class PagesContext
    {
        public static IWebDriver Driver { get; set; }
        public BasePage Common { get; set; }
        public HomePage Home { get; set; }

        public PagesContext()
        {
            Common = new BasePage(Driver);
            Home = new HomePage(Driver);
        }
    }
}