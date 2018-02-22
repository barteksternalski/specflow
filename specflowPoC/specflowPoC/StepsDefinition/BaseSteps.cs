
using specflowPoC.EnvironmentSetup;
using specflowPoC.Pages;

namespace specflowPoC.StepsUI
{
    public class BaseSteps : WebdriverSetup
    {
        protected static CreateUser _createUserPage;

        public static void InitPages()
        {
            _createUserPage = new CreateUser(_driver);
        }

    }
}
