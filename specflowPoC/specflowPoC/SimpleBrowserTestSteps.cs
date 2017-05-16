using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC
{
    [Binding]
    public class SimpleBrowserTestSteps
    {

        private static IWebDriver _driver;

        [AfterFeature]
        public static void tearDownBrowser()
        {
            _driver.Quit();
        }
        [BeforeFeature]
        public static void setupBrowser()
        {
            _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
        }

        [When(@"User opens '(.*)' website")]
        public void WhenUserOpensWebsite(string webAddress)
        {
            _driver.Navigate().GoToUrl(webAddress);
        }

        [Then(@"Website title is '(.*)'")]
        public void ThenWebsiteTitleIs(string webTitle)
        {
            Assert.AreEqual(webTitle, _driver.Title);
        }

        [When(@"User opens registration page")]
        public void WhenUserOpensRegistrationPage()
        {
            _driver.FindElement(By.Id("menu-item-374")).Click();
        }

        [When(@"User fill registration form with following data")]
        public void WhenUserFillRegistrationFormWithFollowingData(Table userInfo)
        {
            dynamic userData = userInfo.CreateDynamicInstance();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("first_name")));


            _driver.FindElement(By.Name("first_name")).SendKeys(userData.FirstName);
            _driver.FindElement(By.Name("last_name")).SendKeys(userData.LastName);

            //var xPathQuery = String.Format("//div[@class='radio_wrap']/input[@value='{0}']", userData.MartialStatus);
            //_driver.FindElement(By.XPath(xPathQuery)).Click();

            //xPathQuery = String.Format("//div[@class='radio_wrap']/input[@value='{0}']", userData.Hobby);
            //_driver.FindElement(By.XPath(xPathQuery)).Click();

            _driver.FindElement(By.XPath("//div[@class='radio_wrap']/input[@value='single']")).Click();
            _driver.FindElement(By.XPath("//div[@class='radio_wrap']/input[@value='dance']")).Click();

            var dropdown = new SelectElement(_driver.FindElement(By.Name("dropdown_7")));
            dropdown.SelectByText(userData.Country);

            _driver.FindElement(By.Name("phone_9")).SendKeys(userData.PhoneNumber.ToString());
            _driver.FindElement(By.Name("username")).SendKeys(userData.Username);
            _driver.FindElement(By.Name("e_mail")).SendKeys(userData.Email);
            _driver.FindElement(By.Name("password")).SendKeys(userData.Password);
            _driver.FindElement(By.Id("confirm_password_password_2")).SendKeys(userData.ConfirmPassword);

            _driver.FindElement(By.Name("pie_submit")).Click();

        }

        [Then(@"User is created")]
        public void ThenUserIsCreated()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Name("first_name")));
            Assert.AreEqual("Thank you for your registration", _driver.FindElement(By.XPath("//*[contains(@class,'piereg_message')]")).Text);
        }


    }
}
