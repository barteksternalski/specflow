using OpenQA.Selenium;
using specflowPoC.Locators;
using System;
using System.Linq;

namespace specflowPoC.Pages
{
    public class ListOfDrafts : BasePage
    {

        public ListOfDrafts(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        public void SelectESlipByName(string name)
        {
            bool contFlag = true;
            while (contFlag)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    if (getElements(By.XPath(ListOfDraftsLocators.XPATH_eSlipByNameCheckbox.Replace("{0}", "name"))).Count > 0)
                    {
                        getElements(By.XPath(ListOfDraftsLocators.XPATH_eSlipByNameCheckbox.Replace("{0}", "name"))).ElementAt(0).Click();
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INFO: ESlip not displayed on current page");
                }
                try
                {
                    if (getElement(By.XPath(ListOfDraftsLocators.XPATH_paginationNextButton)).Enabled)
                    {
                        Console.WriteLine("INFO: Navigate to next page");
                        getElement(By.XPath(ListOfDraftsLocators.XPATH_paginationNextButton)).Click();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INFO: Last page");
                    contFlag = false;
                }
            }
        }

        public void EditESlip()
        {
            getElement(By.XPath(ListOfDraftsLocators.XPATH_editButton)).Click();
        }

        public void DeleteESlip()
        {
            getElement(By.XPath(ListOfDraftsLocators.XPATH_deleteButton)).Click();
        }

        public void SendESlip()
        {
            getElement(By.XPath(ListOfDraftsLocators.XPATH_sendButton)).Click();
        }

        // ******************************** //
        //                                  //
        //          VERIFICATIONS           //
        //                                  //
        // ******************************** //

        public bool VerifyIfESlipIsDisplayed(string name)
        {
            bool contFlag = true;
            while (contFlag)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    if (getElements(By.XPath(ListOfDraftsLocators.XPATH_eSlipByName.Replace("{0}", "name"))).Count > 0)
                    {
                        Console.WriteLine("INFO: Eslip found!");
                        return true;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("INFO: Eslip not displayed on current page!");
                }
                try
                {
                    if (getElement(By.XPath(ListOfDraftsLocators.XPATH_paginationNextButton)).Enabled)
                    {
                        Console.WriteLine("INFO: Navigate to next page");
                        getElement(By.XPath(ListOfDraftsLocators.XPATH_paginationNextButton)).Click();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INFO: Last page");
                    contFlag = false;
                }
            }
            return false;
        }

    }
}
