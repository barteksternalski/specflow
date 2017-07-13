using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace Infusion.Specflow.Tests.Template.Extensions
{
    public static class IWebElementExtensions
    {
        public static IWebElement JsClick(this IWebElement element, IWebDriver driver)
        {
            // This method fixes weird behavior when Edge throws exeption with "Element obscured"
            try
            {
                element.Click();
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ElementNotVisibleException)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            }
            return element;
        }

        public static IWebElement WaitForInvisible(this IWebElement element, TimeSpan? span = null)
        {
            if (span == null)
            {
                span = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings.Get("WaitElementTimeoutInSeconds")));
            }

            IWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = (TimeSpan)span,
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            Console.WriteLine(element.Displayed);
            try
            {
                bool Waiter(IWebElement el) => !el.Displayed;
                wait.Until(Waiter);
            }
            catch (StaleElementReferenceException) { }

            return element;
        }

        public static IWebElement WaitForVisible(this IWebElement element, TimeSpan? span = null)
        {
            if (span == null)
            {
                span = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings.Get("WaitElementTimeoutInSeconds")));
            }

            IWait<IWebElement> wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = (TimeSpan)span,
                PollingInterval = TimeSpan.FromMilliseconds(50)
            };
            try
            {
                bool Waiter(IWebElement el) => el.Displayed;
                wait.Until(Waiter);
            }
            catch (StaleElementReferenceException) { }

            return element;
        }
    }
}