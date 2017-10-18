using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using specflowPoC.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC.Pages
{
    public class CreateSingleESlip : BasePage
    {

        public CreateSingleESlip(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        public void FillCustomerInformation(IWebDriver driver, String name, Table dataTable)
        {
            dynamic userData = dataTable.CreateDynamicInstance();

            if (!userData.EslipName.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_nameInputField)).SendKeys(name);
            if (!userData.PolicyNumber.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_policyNumberInputField)).SendKeys(userData.PolicyNumber);
            if (!userData.Email.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_emailInputField)).SendKeys(userData.Email);
            if (!userData.PhoneNumber.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_phoneNumberInputField)).SendKeys(userData.PhoneNumber);
            if (!userData.Language.Equals("{null}"))
            {
                getElement(By.Id(CreateSingleESlipLocators.ID_languageDropdown)).Click();
                foreach (IWebElement option in getElements(By.XPath(CreateSingleESlipLocators.XPATH_dropdownOptions)))
                {
                    if (option.Text.Equals(userData.Language))
                    {
                        option.Click();
                        break;
                    }
                }
            }
            if (!userData.Province.Equals("{null}"))
            {
                getElement(By.Id(CreateSingleESlipLocators.ID_provinceDropdown)).Click();
                foreach (IWebElement option in getElements(By.XPath(CreateSingleESlipLocators.XPATH_dropdownOptions)))
                {
                    if (option.Text.Equals(userData.Province))
                    {
                        option.Click();
                        break;
                    }
                }
            }
            if (!userData.AddressLine1.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_contactAddress1InputField)).SendKeys(userData.AddressLine1);
            if (!userData.AddressLine2.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_contactAddress2InputField)).SendKeys(userData.AddressLine2);
            if (!userData.City.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_contactCityInputField)).SendKeys(userData.City);
            if (!userData.PostalCode.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_contactPostalCodeInputField)).SendKeys(userData.PostalCode);
            if (!userData.EffectiveDate.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_effectiveDateInputField)).SendKeys(userData.EffectiveDate);
            if (!userData.ExpirationDate.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.ID_expirationDateInputField)).SendKeys(userData.ExpirationDate);
            if (!userData.Insurer.Equals("{null}"))
            {
                System.Threading.Thread.Sleep(1000);
                Actions builder = new Actions(driver);
                builder
                    .MoveToElement(getElement(By.XPath(CreateSingleESlipLocators.XPATH_carrierInputField)))
                    .Click()
                    .SendKeys(userData.Insurer)
                    .Pause(1000)
                    .SendKeys(Keys.Enter)
                    .Build()
                    .Perform();

            }
            if (!userData.Brokerage.Equals("{null}")) getElement(By.Id(CreateSingleESlipLocators.XPATH_brokerageInputField)).SendKeys(userData.Brokerage);
        }

        public void SaveDraft()
        {
            getElement(By.Id(CreateSingleESlipLocators.XPATH_saveDraftButton)).Click();
            System.Threading.Thread.Sleep(1500);
        }

        // ******************************** //
        //                                  //
        //          VERIFICATIONS           //
        //                                  //
        // ******************************** //

    }
}
