using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace specflowPoC.StepsUI
{
    [Binding]
    class APISteps
    {
        RestClient client = new RestClient();

        [Given(@"System API is up and running")]
        public void GivenSystemAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("http://cssitcacapi01-dev.azurewebsites.net");
        }

        [When(@"User sends sign in request with following data")]
        public void WhenUserSendsSignInRequestWithFollowingData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Access token is sent back by the system")]
        public void ThenAccessTokenIsSentBackByTheSystem()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"System responses with proper error '(.*)'")]
        public void ThenSystemResponsesWithProperError(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
