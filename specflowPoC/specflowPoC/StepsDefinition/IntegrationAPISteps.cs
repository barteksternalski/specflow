using System;
using RestSharp;
using TechTalk.SpecFlow;
using specflowPoC.Helpers;
using specflowPoC.TestDataObjects;
using Newtonsoft.Json;
using NUnit.Framework;

namespace specflowPoC.StepsUI
{
    [Binding]
    class IntegrationAPISteps
    {
        static IRestClient client = new RestClient();
        static IRestResponse response;

        [Given(@"Application API is up and running")]
        public void GivenApplicationAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("https://nice-unison-194320.appspot.com");
        }

        [When(@"User sends API request to calculate FIE parameters with following data")]
        public void WhenUserSendsAPIRequestToCalculateFIEParametersWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest("/api/fie/calculate", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getFIERequestPayload(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"FIE parameters are calculated")]
        public void ThenFIEParametersAreCalculated()
        {
            FIEResponsePayloadObject results = JsonConvert.DeserializeObject<FIEResponsePayloadObject>(response.Content);
            Assert.AreEqual("OK", response.StatusDescription);
        }

        [When(@"User sends API request to calculate FIT parameters with following data")]
        public void WhenUserSendsAPIRequestToCalculateFITParametersWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest("/api/fit/calculate", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getFITRequestPayload(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"FIT parameters are calculated")]
        public void ThenFITParametersAreCalculated()
        {
            FITResponsePayloadObject results = JsonConvert.DeserializeObject<FITResponsePayloadObject>(response.Content);
            Assert.AreEqual("OK", response.StatusDescription);
        }

    }
}
