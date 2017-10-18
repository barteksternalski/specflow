using OpenQA.Selenium;
using specflowPoC.Locators;
using System;
using System.Windows.Forms;

namespace specflowPoC.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        public void Login(string username, string password)
        {
            try
            {
                getElement(By.XPath(LoginPageLocators.XPATH_useAnotherAccountButton)).Click();
            } catch (Exception e)
            {
                Console.WriteLine("INFO: First user to login");
            }
            getElement(By.Id(LoginPageLocators.ID_userNameInputField)).SendKeys(username);
            SendKeys.SendWait("{TAB}");
            System.Threading.Thread.Sleep(1000);
            getElement(By.Id(LoginPageLocators.ID_passwordInputField)).SendKeys(password);
            getElement(By.Id(LoginPageLocators.ID_loginButton)).Click();
        }

        // ******************************** //
        //                                  //
        //          VERIFICATIONS           //
        //                                  //
        // ******************************** //

    }
}
