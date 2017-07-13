using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Infusion.Specflow.Tests.Template.Utilities
{
    internal static class WebDriverHelper
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitDriver.");
                }
                return _driver;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (_driver == null)
                    {
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }

                    break;

                case "IE":
                    if (_driver == null)
                    {
                        new DriverManager().SetUpDriver(new InternetExplorerConfig(), "Latest", Architecture.X32);
                        _driver = new InternetExplorerDriver();
                        Drivers.Add("IE", Driver);
                    }

                    break;

                case "Edge":
                    if (_driver == null)
                    {
                        // Calling for the particular version does not work
                        //new DriverManager().SetUpDriver(new EdgeConfig(), "3.14393");
                        // let's configure driver manually:
                        new DriverManager().SetUpDriver(
                            "https://download.microsoft.com/download/3/2/D/32D3E464-F2EF-490F-841B-05D53C848D15/MicrosoftWebDriver.exe",
                            Path.Combine(Directory.GetCurrentDirectory(), "Edge", "3.14393", "X64", "MicrosoftWebDriver.exe"), "MicrosoftWebDriver.exe");
                        _driver = new EdgeDriver();
                        Drivers.Add("Edge", Driver);
                    }

                    break;

                case "Chrome":
                    if (_driver == null)
                    {
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        var options = new ChromeOptions();
                        options.AddArguments("--start-maximized");
                        options.AddArguments("--disable-notifications");
                        options.AddArguments("--disable-infobars");
                        _driver = new ChromeDriver(options);
                        Drivers.Add("Chrome", Driver);
                    }

                    break;
                
                default:
                    throw new ArgumentException("Wrong argument selected");
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(double.Parse(ConfigurationManager.AppSettings.Get("ImplicitWaitInMiliseconds")));
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(double.Parse(ConfigurationManager.AppSettings.Get("DefaultPageLoadTimeoutInSeconds")));
            Driver.Manage().Window.Maximize();
        }

        public static void InitBrowser()
        {
            if (_driver == null)
            {
                InitBrowser(ConfigurationManager.AppSettings.Get("DefaultBrowser"));
            }
        }

        public static void OpenUrl(string url)
        {
            Driver.Url = url;
            Driver.Navigate();
        }

        public static void OpenUrl()
        {
            OpenUrl(ConfigurationManager.AppSettings.Get("ServerAddress"));
        }

        public static void Login()
        {
            foreach (var key in Drivers.Keys)
            {
                switch (key)
                {
                    case "Firefox":
                        break;

                    case "IE":
                        break;

                    case "Edge":
                        break;

                    case "Chrome":
                        break;
                }
            }
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                foreach (var handle in Drivers[key].WindowHandles)
                {
                    Drivers[key].SwitchTo().Window(handle).Close();
                }
                Drivers[key].Quit();
            }
        }
    }
}