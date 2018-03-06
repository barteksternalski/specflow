using OpenQA.Selenium;
using specflowPoC.Locators;
using specflowPoC.TestDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC.Pages
{
    public class CreateUser : BasePage
    {

        public CreateUser(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        private void SelectUserType(string type)
        {
            System.Threading.Thread.Sleep(1000);
            switch (type)
            {
                case "Organization":
                    getElements(By.XPath(CreateUserLocators.XPATH_userTyperadioButton)).ElementAt(1).Click();
                    break;
                case "User":
                    getElements(By.XPath(CreateUserLocators.XPATH_userTyperadioButton)).ElementAt(2).Click();
                    getElements(By.XPath(CreateUserLocators.XPATH_userTyperadioButton)).ElementAt(0).Click();
                    break;
                case "CSIO Admin":
                    getElements(By.XPath(CreateUserLocators.XPATH_userTyperadioButton)).ElementAt(2).Click();
                    break;
                default:
                    Console.WriteLine($"INFO: There is no '{type}' user");
                    break;
            }
        }

        private void SelectOrganizationType(String type)
        {
            System.Threading.Thread.Sleep(1000);
            switch (type)
            {
                case "Carrier":
                    getElements(By.XPath(CreateUserLocators.XPATH_organizationTypeRadioButton)).ElementAt(1).Click();
                    break;
                case "Brokerage":
                    getElements(By.XPath(CreateUserLocators.XPATH_organizationTypeRadioButton)).ElementAt(1).Click();
                    getElements(By.XPath(CreateUserLocators.XPATH_organizationTypeRadioButton)).ElementAt(0).Click();
                    break;
                default:
                    Console.WriteLine($"INFO: There is no '{type}' organization");
                    break;
            }
        }

        private void SelectModules(String listOfModules)
        {
            List<string> modules = listOfModules.Split(',').ToList();
            foreach (string str in modules)
            {
                getElement(By.XPath(CreateUserLocators.XPATH_accessToModulesCheckbox.Replace("{0}", str))).Click();
            }
        }

        
    }
}
