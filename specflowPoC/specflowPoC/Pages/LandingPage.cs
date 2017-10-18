using OpenQA.Selenium;
using specflowPoC.Locators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace specflowPoC.Pages
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        public void NavigateToTab(String location)
        {
            switch (location)
            {
                case "Dashboard":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "dashboard"))).Click();
                    break;
                case "Reporting":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "reporting"))).Click();
                    break;
                case "Create Single":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createsingle"))).Click();
                    break;
                case "Create Bulk":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createbulk"))).Click();
                    break;
                case "Drafts":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "drafts"))).Click();
                    break;
                case "Sent":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "sent"))).Click();
                    break;
                case "E-mail":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "emailtemplate"))).Click();
                    break;
                case "E-Slip Back":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "eslipbacktemplate"))).Click();
                    break;
                case "Create User":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createuser"))).Click();
                    break;
                case "User List":
                    getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "listusers"))).Click();
                    break;
                default:
                    Console.WriteLine($"INFO: There is no '{location}' navigation link!");
                    break;
            }
        }

        public void MainViewNavigation()
        {
            getElement(By.XPath(LandingPageLocators.XPATH_logoIcon)).Click();
        }

        public void Logout()
        {
            getElement(By.XPath(LandingPageLocators.XPATH_logoutButton)).Click();
        }


        // ******************************** //
        //                                  //
        //          VERIFICATIONS           //
        //                                  //
        // ******************************** //

        public bool VerifyIfMainPageIsDisplayed()
        {
            return getElement(By.XPath(LandingPageLocators.XPATH_logoutButton)).Displayed;
        }

        private bool VerifyAccessToGivenLocation(string location)
        {
            try
            {
                switch (location)
                {
                    case "Dashboard":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "dashboard"))).Displayed;
                    case "Reporting":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "reporting"))).Displayed;
                    case "Create Single":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createsingle"))).Displayed;
                    case "Create Bulk":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createbulk"))).Displayed;
                    case "Drafts":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "drafts"))).Displayed;
                    case "Sent":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "sent"))).Displayed;
                    case "E-mail":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "emailtemplate"))).Displayed;
                    case "E-Slip Back":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "eslipbacktemplate"))).Displayed;
                    case "Create User":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "createuser"))).Displayed;
                    case "User List":
                        return getElement(By.XPath(LandingPageLocators.XPATH_navigationLink.Replace("{0}", "listusers"))).Displayed;
                    default:
                        Console.WriteLine($"INFO: There is no '{location}' navigation link!");
                        break;
                }
            } catch (Exception e)
            {
                Console.WriteLine($"INFO: Location '{location}' is not available for given user!");
            }
            return false;
        }

        public bool VerifyAvailableModules(string accessModules)
        {
            bool localFlag = true;
            List<string> modules = accessModules.Split(',').ToList();
            foreach (string str in modules)
            {
                if (VerifyAccessToGivenLocation(str)) {
                    Console.WriteLine($"INFO: Access to '{str}' module verified");
                } else
                {
                    Console.WriteLine($"INFO: Inappriopriate access to '{str}' module");
                    localFlag = false;
                }
            }
            return localFlag;
        }

        public bool VerifyUnavailableModules(string accessModules)
        {
            bool localFlag = true;
            List<string> modules = accessModules.Split(',').ToList();
            foreach (string str in modules)
            {
                if (VerifyAccessToGivenLocation(str))
                {
                    Console.WriteLine($"INFO: Inappriopriate access to '{str}' module");
                    localFlag = false;
                }
                else
                {
                    Console.WriteLine($"INFO: Access to '{str}' module verified");
                }
            }
            return localFlag;
        }

    }
}
