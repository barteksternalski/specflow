using NUnit.Framework;
using specflowPoC.Helpers;
using specflowPoC.StepsUI;
using TechTalk.SpecFlow;

namespace specflowPoC
{
    [Binding]
    public class GeneralSteps : BaseSteps
    {

        static string userId = "";
        static string eSlipName = "";

        [Given(@"Clear email account")]
        public void ClearEmailAccount()
        {
            GmailExtractor.DeleteMessages();
            Assert.AreEqual(0, GmailExtractor.GetNoOfMessages());
        }

        [Given(@"Generate unique name")]
        public void GivenGenerateUniqueName()
        {
            userId = Procedures.GenerateRandomizedStringWithLength(8);
            eSlipName = Procedures.GenerateRandomizedStringWithLength(10);
        }

        [Given(@"Setup '(.*)' browser")]
        public void GivenSetupBrowser(string browser)
        {
            InitBrowser(browser);
            InitPages();
        }

        [Given(@"User is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            _loginPage.OpenURL("http://cssitcacweb01-dev.azurewebsites.net");
        }

        [When(@"User enters '(.*)' and '(.*)'")]
        public void WhenUserEntersAnd(string username, string password)
        {
            _loginPage.Login(username, password);
        }

        [Then(@"Main page is displayed")]
        public void ThenMainPageIsDisplayed()
        {
            Assert.IsTrue(_landingPage.VerifyIfMainPageIsDisplayed());
        }

        [Given(@"User is on dashboard page")]
        public void GivenUserIsOnDashboardPage()
        {
            _landingPage.MainViewNavigation();
        }

        [When(@"User creates new user with given data")]
        public void WhenUserCreatesNewUserWithGivenData(Table table)
        {
            _landingPage.NavigateToTab("Create User");
            _createUserPage.CreateNewUser(table, userId);
        }

        [Then(@"User '(.*)' is created")]
        public void ThenUserIsCreated(string user)
        {
            _landingPage.NavigateToTab("User List");
            Assert.IsTrue(_listOfUsers.VerifyIfUserIsListed(user));
        }

        [When(@"User logs out")]
        public void WhenUserLogsOut()
        {
            _landingPage.Logout();
        }

        [Given(@"Close browser")]
        public void GivenCloseBrowser()
        {
            CloseDriver();
        }

        [When(@"Created user enters '(.*)' and '(.*)'")]
        public void WhenCreatedUserEntersAnd(string username, string password)
        {
            string pass = GmailExtractor.GetPasswordFromLastEmail();
            GmailExtractor.DeleteMessages();
            _loginPage.Login(userId + "@csiodev.onmicrosoft.com", pass);
        }

        [Then(@"User has access to '(.*)' modules")]
        public void ThenUserHasAccessToModules(string modulesList)
        {
            Assert.IsTrue(_landingPage.VerifyAvailableModules(modulesList));
        }

        [Then(@"User does not have access to '(.*)' modules")]
        public void ThenUserDoesNotHaveAccessToModules(string modulesList)
        {
            Assert.IsTrue(_landingPage.VerifyUnavailableModules(modulesList));
        }

        [Given(@"User is creating new eEslip")]
        public void GivenUserIsCreatingNewEEslip()
        {
            _landingPage.NavigateToTab("Create Single");
        }

        [When(@"User creates new eSlip with given customer and policy information with given data")]
        public void WhenUserCreatesNewESlipWithGivenCustomerAndPolicyInformationWithGivenData(Table table)
        {
            _createSingleESlip.FillCustomerInformation(_driver, eSlipName, table);
        }

        [When(@"User saves eSlip draft")]
        public void WhenUserSavesESlipDraft()
        {
            _createSingleESlip.SaveDraft();
        }

        [Then(@"ESlip '(.*)' is displayed on Drafts list")]
        public void ThenESlipIsDisplayedOnDraftsList(string draftName)
        {
            _landingPage.NavigateToTab("Drafts");
            Assert.IsTrue(_listOfDrafts.VerifyIfESlipIsDisplayed(draftName));
        }


    }
}
