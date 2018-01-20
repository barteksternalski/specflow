using System;
using RestSharp;
using TechTalk.SpecFlow;
using specflowPoC.Helpers;
using NUnit.Framework;
using System.Xml.Linq;

namespace specflowPoC.StepsUI
{
    [Binding]
    class IntegrationAPISteps
    {
        IRestClient client = new RestClient();
        IRestResponse response;

        [Given(@"System API is up and running")]
        public void GivenSystemAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("http://cssitcacapi01-dev.azurewebsites.net/");
        }

        [When(@"User sends sign in request with following data")]
        public void WhenUserSendsSignInRequestWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest("api/integration/login", Method.POST);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getLoginXML(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Access token is sent back by the system")]
        public void ThenAccessTokenIsSentBackByTheSystem()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("Response").Element("Status").Value);
        }

        [Then(@"System responses with proper error '(.*)'")]
        public void ThenSystemResponsesWithProperError(string message)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
