using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace specflowPoC.EnvironmentSetup
{
    internal static class WebdriverSetup
    {
        private static IWebDriver _driver;

        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    var options = new ChromeOptions();
                    options.AddArguments("--start-maximized");
                    options.AddArguments("--disable-notifications");
                    options.AddArguments("--disable-infobars");
                    _driver = new ChromeDriver(options);
                    break;
                default:
                    throw new ArgumentException("Wrong argument selected");
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(double.Parse(ConfigurationManager.AppSettings.Get("ImplicitWaitInMiliseconds")));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings.Get("DefaultPageLoadTimeoutInSeconds")));

            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Dispose();
        }

    }
}
