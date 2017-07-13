using Infusion.Specflow.Tests.Template.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Infusion.Specflow.Tests.Template.TestSteps
{
    [Binding]
    internal class ApiSteps
    {
        private static IRestResponse _response;

        [Given(@"I send the (.*) request to the ""(.*)"".*")]
        [When(@"I send the (.*) request to the ""(.*)"".*")]
        public void SendRequest(string type, string endpoint)
        {
            var request = new RestRequest(endpoint);
            var restClient = new RestClient(ConfigurationManager.AppSettings.Get("ApiServerAddress"));

            request.AddHeader("accept", "application/json");
            switch (type)
            {
                case "GET":
                    _response = restClient.Get(request);
                    break;
            }
        }

        // multiple annotations are needed, cause specflow stepdefinitions report does not work with [StepDefinition] steps
        [Given(@"I receive the response with response code: ""(.*)""")]
        [When(@"I receive the response with response code: ""(.*)""")]
        [Then(@"I receive the response with response code: ""(.*)""")]
        public void CheckResponseCode(int responseCode)
        {
            Console.WriteLine(_response.Content);
            Assert.AreEqual(responseCode, (int)_response.StatusCode);
        }

        [Then(@"response contains comic details:")]
        public void CheckComicDetails(Table table)
        {
            var comicDetails = JsonConvert.DeserializeObject<XkcdResponse>(_response.Content);
            table.CompareToInstance(comicDetails);
        }
    }
}