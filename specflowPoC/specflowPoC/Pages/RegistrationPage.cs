using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace specflowPoC
{
    public class RegistrationPage : BasePage
    {

        // elements
        private By registrationNavigation = By.Id("menu-item-374");
        private By firstNameInput = By.Name("first_name");
        private By lastNameInput = By.Name("last_name");
        private By countryDropdown = By.Name("dropdown_7");
        private By phoneInput = By.Name("phone_9");
        private By usernameInput = By.Name("username");
        private By emailInput = By.Name("e_mail");
        private By passwordInput = By.Name("password");
        private By confirmationInput = By.Id("confirm_password_password_2");
        private By registerButton = By.Name("pie_submit");
        private By successRegistrationMessage = By.XPath("//p[contains(@class,'piereg')]");
        private By statusSelector(String status)
        {
            var xPathQuery = String.Format("//div[@class='radio_wrap']/input[@value='{0}']", status);
            return By.XPath(xPathQuery);
        }

        //constructor
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        //methods
        public void openRegistrationForm()
        {
            getElement(registrationNavigation).Click();
        }

        public void enterFirstName(String name)
        {
            getElement(firstNameInput).SendKeys(name);
        }

        public void enterLastName(String name)
        {
            getElement(lastNameInput).SendKeys(name);
        }

        public void selectMartialStatus(String status)
        {
            getElement(statusSelector(status)).Click();
        }

        public void selectHobby(String status)
        {
            getElement(statusSelector(status)).Click();
        }

        public void selectCountry(String country)
        {
            var dropdown = new SelectElement(getElement(countryDropdown));
            dropdown.SelectByText(country);
        }

        public void enterPhoneNumber(String phone)
        {
            getElement(phoneInput).SendKeys(phone);
        }

        public void enterUsername(String name)
        {
            getElement(usernameInput).SendKeys(name);
        }

        public void enterEmail(String email)
        {
            getElement(emailInput).SendKeys(email);
        }

        public void enterPassword(String password)
        {
            getElement(passwordInput).SendKeys(password);
        }

        public void enterPasswordConfirmation(String confirmation)
        {
            getElement(confirmationInput).SendKeys(confirmation);
        }

        public String getConfirmationMessage()
        {
            return getElement(successRegistrationMessage).Text;
        }

        public void submitForm()
        {
            getElement(registerButton).Click();
        }

    }
}
