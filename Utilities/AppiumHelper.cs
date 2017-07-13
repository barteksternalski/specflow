using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace Infusion.Specflow.Tests.Template.Utilities
{
    internal class AppiumHelper
    {
        private static AndroidDriver<IWebElement> _driver;
        private static AppiumLocalService _service;

        public static AndroidDriver<IWebElement> Driver
        {
            get
            {
                if (_driver == null)
                {
                    throw new NullReferenceException("The WebDriver appium instance was not initialized. You should first call the method InitEmulator.");
                }
                return _driver;
            }
        }

        public static void InitEmulator(string imageName)
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(AndroidMobileCapabilityType.Avd, imageName);
            capabilities.SetCapability(AndroidMobileCapabilityType.AvdArgs, ConfigurationManager.AppSettings.Get("EmulatorCmdOptions"));
            capabilities.SetCapability(AndroidMobileCapabilityType.AndroidDeviceReadyTimeout, int.Parse(ConfigurationManager.AppSettings.Get("EmulatorReadyTimeoutInSeconds")));
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "Android Emulator");
            capabilities.SetCapability(MobileCapabilityType.App, Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + $@"TestFiles\{ConfigurationManager.AppSettings.Get("AppFileName")}"));
            capabilities.SetCapability(AndroidMobileCapabilityType.AppWaitPackage, ConfigurationManager.AppSettings.Get("AppAndroidPackageName"));

            var args = new OptionCollector().AddCapabilities(capabilities);

            //Start Appium Server
            //_service = new AppiumServiceBuilder().WithArguments(args).WithLogFile(new FileInfo("D:\\appium.log")).Build();
            _service = new AppiumServiceBuilder().WithArguments(args).Build();
            _service.Start();

            // Start Emulator
            _driver = new AndroidDriver<IWebElement>(_service.ServiceUrl, capabilities, TimeSpan.FromSeconds(60));
        }

        public static void CloseEmulator()
        {
            // Quit driver
            _driver.Quit();
            //Stop Appium server
            _service.Dispose();
            //Close the Emulator
            var emulatorProcess = Process.GetProcessesByName("qemu-system-x86_64");
            emulatorProcess[0].CloseMainWindow();
        }
    }
}