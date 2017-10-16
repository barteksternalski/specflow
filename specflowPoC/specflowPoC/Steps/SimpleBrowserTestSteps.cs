using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC
{
    [Binding]
    public class SimpleBrowserTestSteps : BaseSteps
    {

        [When(@"User opens '(.*)' website")]
        public void WhenUserOpensWebsite(string webAddress)
        {
            registrationPage.Navigate(webAddress);
        }

        [Then(@"Website title is '(.*)'")]
        public void ThenWebsiteTitleIs(string webTitle)
        {
            Assert.AreEqual(webTitle, registrationPage.getPageTitle());
        }

        [When(@"User opens registration page")]
        public void WhenUserOpensRegistrationPage()
        {
            registrationPage.openRegistrationForm();
        }

        [When(@"User fill registration form with following data")]
        public void WhenUserFillRegistrationFormWithFollowingData(Table userInfo)
        {
            dynamic userData = userInfo.CreateDynamicInstance();

            registrationPage.enterFirstName(userData.FirstName);
            registrationPage.enterLastName(userData.LastName);
            registrationPage.selectMartialStatus(userData.MartialStatus);
            registrationPage.selectHobby(userData.Hobby);
            registrationPage.selectCountry(userData.Country);
            registrationPage.enterPhoneNumber(userData.PhoneNumber.ToString());
            registrationPage.enterUsername(userData.Username);
            registrationPage.enterEmail(userData.Email);
            registrationPage.enterPassword(userData.Password);
            registrationPage.enterPasswordConfirmation(userData.ConfirmPassword);
            registrationPage.submitForm();

        }

        [Then(@"Message (.*) is displayed")]
        public void ThenMessageIsDisplayed(string message)
        {
            Assert.AreEqual(message, registrationPage.getConfirmationMessage());
        }
    }
}
