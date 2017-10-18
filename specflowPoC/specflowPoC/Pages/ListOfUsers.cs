using OpenQA.Selenium;
using specflowPoC.Locators;
using System;
using System.Linq;

namespace specflowPoC.Pages
{
    public class ListOfUsers : BasePage
    {
        public ListOfUsers(IWebDriver driver) : base(driver)
        {
        }

        // ******************************** //
        //                                  //
        //              ACTIONS             //
        //                                  //
        // ******************************** //

        public void SelectuserByName(string name)
        {
            bool contFlag = true;
            while (contFlag)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    if (getElements(By.XPath(ListOfUsersLocators.XPATH_listOfUserNames.Replace("{0}", "name"))).Count > 0)
                    {
                        getElements(By.XPath(ListOfUsersLocators.XPATH_listOfUserNames.Replace("{0}", "name"))).ElementAt(0).Click();
                        break;
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("INFO: user not displayed on current page");
                }
                try
                {
                    if (getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Enabled)
                    {
                        Console.WriteLine("INFO: Navigate to next page");
                        getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Click();
                    }
                } catch (Exception e)
                {
                    Console.WriteLine("INFO: Last page");
                    contFlag = false;
                }
            }
        }

        public string GetUserActivationStatus(string name)
        {
            bool contFlag = true;
            string result = "";
            while (contFlag)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    if (getElements(By.XPath(ListOfUsersLocators.XPATH_userByNameActivationStatus.Replace("{0}", "name"))).Count > 0)
                    {
                        result = getElements(By.XPath(ListOfUsersLocators.XPATH_userByNameActivationStatus.Replace("{0}", "name"))).ElementAt(0).Text;
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INFO: user not displayed on current page");
                }
                try
                {
                    if (getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Enabled)
                    {
                        Console.WriteLine("INFO: Navigate to next page");
                        getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Click();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("INFO: Last page");
                    contFlag = false;
                }
            }
            return result;
        }

        public void EditUser()
        {
            getElement(By.XPath(ListOfUsersLocators.XPATH_editButton)).Click();
        }

        public void DeleteUser()
        {
            getElement(By.XPath(ListOfUsersLocators.XPATH_deleteButton)).Click();
        }

        public void ActivateUser()
        {
            getElement(By.XPath(ListOfUsersLocators.XPATH_activateButton)).Click();
        }

        public void DeactivateUser()
        {
            getElement(By.XPath(ListOfUsersLocators.XPATH_deactivateButton)).Click();
        }

        public void ResetPassword()
        {
            getElement(By.XPath(ListOfUsersLocators.XPATH_resetPasswordButton)).Click();
        }

        // ******************************** //
        //                                  //
        //          VERIFICATIONS           //
        //                                  //
        // ******************************** //

        public bool VerifyIfUserIsListed(string name)
        {
            bool contFlag = true;
            while (contFlag)
            {
                System.Threading.Thread.Sleep(1000);
                if (getElements(By.XPath(ListOfUsersLocators.XPATH_listOfUserNames)).Count > 0)
                {
                    foreach (IWebElement user in getElements(By.XPath(ListOfUsersLocators.XPATH_listOfUserNames)))
                    {
                        if (user.Text.Equals(name))
                        {
                            Console.WriteLine("INFO: User found!");
                            return true;
                        }
                    }
                    Console.WriteLine("INFO: User not found!");
                } else
                {
                    Console.WriteLine("INFO: User list is empty!");
                }
                try
                {
                    if (getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Enabled)
                    {
                        Console.WriteLine("INFO: Navigate to next page");
                        getElement(By.XPath(ListOfUsersLocators.XPATH_paginationNextButton)).Click();
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
