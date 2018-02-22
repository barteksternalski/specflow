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

    }
}
