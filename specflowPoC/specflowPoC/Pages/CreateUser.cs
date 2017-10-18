using OpenQA.Selenium;
using specflowPoC.Locators;
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

        public void CreateNewUser(Table dataTable, String userId)
        {
            dynamic userData = dataTable.CreateDynamicInstance();

            if (!userData.UserType.Equals("{null}")) SelectUserType(userData.UserType);
            if (!userData.UserId.Equals("{null}")) getElement(By.Id(CreateUserLocators.ID_userIdInputField)).SendKeys(userId);
            if (!userData.UserName.Equals("{null}")) getElement(By.Id(CreateUserLocators.ID_nameInputField)).SendKeys(userData.UserName);
            if (!userData.Email.Equals("{null}")) getElement(By.Id(CreateUserLocators.ID_emailInputField)).SendKeys(userData.Email);
            if (!userData.OrganizationId.Equals("{null}")) getElement(By.Id(CreateUserLocators.ID_organizationUserIdInputField)).SendKeys(userData.OrganizationId);
            if (!userData.OrganizationType.Equals("{null}")) SelectOrganizationType(userData.OrganizationType);
            if (!userData.CsioNetId.Equals("{null}")) getElement(By.Id(CreateUserLocators.ID_csioNetIdInputField)).SendKeys(userData.CsioNetId);
            if (!userData.Carrier.Equals("{null}"))
            {
                getElement(By.Id(CreateUserLocators.ID_carrierOrganizationDropdown)).Click();
                foreach (IWebElement option in getElements(By.XPath(CreateUserLocators.XPATH_dropdownOptions)))
                {
                    if (option.Text.Equals(userData.Carrier))
                    {
                        option.Click();
                        break;
                    }
                }
            } else Console.WriteLine("INFO: Field \"Carrier Organization\" set to NULL value");
            if (!userData.Broker.Equals("{null}"))
            {
                getElement(By.Id(CreateUserLocators.ID_brokerageOrganizationDropdown)).Click();
                foreach (IWebElement option in getElements(By.XPath(CreateUserLocators.XPATH_dropdownOptions)))
                {
                    if (option.Text.Equals(userData.Broker))
                    {
                        option.Click();
                        break;
                    }
                }
            }
            else Console.WriteLine("INFO: Field \"Brokerage Organization\" set to NULL value");
            if (!userData.Modules.Equals("{null}")) SelectModules(userData.Modules);

            getElement(By.XPath(CreateUserLocators.XPATH_saveButton)).Click();
            System.Threading.Thread.Sleep(1000);
        }

    }
}
