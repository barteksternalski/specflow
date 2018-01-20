
using specflowPoC.EnvironmentSetup;
using specflowPoC.Pages;

namespace specflowPoC.StepsUI
{
    public class BaseSteps : WebdriverSetup
    {
        protected static CreateUser _createUserPage;
        protected static LoginPage _loginPage;
        protected static LandingPage _landingPage;
        protected static ListOfUsers _listOfUsers;
        protected static CreateSingleESlip _createSingleESlip;
        protected static ListOfDrafts _listOfDrafts;

        public static void InitPages()
        {
            _createUserPage = new CreateUser(_driver);
            _loginPage = new LoginPage(_driver);
            _landingPage = new LandingPage(_driver);
            _listOfUsers = new ListOfUsers(_driver);
            _createSingleESlip = new CreateSingleESlip(_driver);
            _listOfDrafts = new ListOfDrafts(_driver);
        }

    }
}
