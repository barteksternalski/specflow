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
        static IRestClient client = new RestClient();
        static IRestResponse response;
        static String token = "";

        [Given(@"System API on '(.*)' environment is up and running")]
        public void GivenSystemAPIIsUpAndRunning(string environemnt)
        {
            switch(environemnt)
            {
                case "DEV":
                    client.BaseUrl = new Uri("http://cssitcacapi01-dev.azurewebsites.net");
                    break;
                case "SIT":
                    client.BaseUrl = new Uri("http://cssitcacapi01.azurewebsites.net");
                    break;
                case "UAT":
                    client.BaseUrl = new Uri("http://csuatcecapi01.azurewebsites.net");
                    break;
            }
            
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
            token = parsedResponse.Element("Response").Element("Token").Value;
        }

        [Then(@"System responses with proper error '(.*)'")]
        public void ThenSystemResponsesWithProperError(string message)
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Error", parsedResponse.Element("Response").Element("Status").Value);
            Assert.IsTrue(parsedResponse.Element("Response").Element("Message").Value.Contains(message));
        }

        [When(@"User sends eSlip creation request with following data")]
        public void WhenUserSendsESlipCreationRequestWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest("api/integration/eslip", Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getESlipXML(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"ESlip is properly created in the system")]
        public void ThenESlipIsProperlyCreatedInTheSystem()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("eSlipRs").Element("MsgStatus").Element("MsgStatusCd").Value);
        }


    }
}
