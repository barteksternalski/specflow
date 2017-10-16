using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace specflowPoC
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(String url)
        {
            _driver.Navigate().GoToUrl(url);
            if (_driver.WindowHandles.Count > 1) _driver.SwitchTo().Window(_driver.WindowHandles[1]);
        }

        public IWebElement getElement(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return _driver.FindElement(locator);
            } 
            catch (NoSuchElementException ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }

        public String getPageTitle()
        {
            return _driver.Title;
        }
    }
}
