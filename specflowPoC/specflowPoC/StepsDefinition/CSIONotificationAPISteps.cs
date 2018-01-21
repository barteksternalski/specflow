using System;
using RestSharp;
using TechTalk.SpecFlow;
using specflowPoC.Helpers;
using NUnit.Framework;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace specflowPoC.StepsDefinition
{
    [Binding]
    class CSIONotificationAPISteps
    {
        static IRestClient client = new RestClient();
        static IRestResponse response;
        static String sessionGUID, userGUID;

        [Given(@"CsioNET API is up and running")]
        public void GivenCsioNETAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("https://qa-web.csionet.com/v1/MessageServices.aspx");
        }

        [When(@"User sends sign in request to CsioNET with following data")]
        public void WhenUserSendsSignInRequestToCsioNETWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getCSIONetLoginXML(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"CsioNET system responses with proper error '(.*)'")]
        public void ThenCsioNETSystemResponsesWithProperError(string message)
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Failed", parsedResponse.Element("Response").Element("Status").Value);
            Assert.IsTrue(parsedResponse.Element("Response").Element("Exception").Value.Contains(message));
        }

        [Then(@"CsioNET sessionID is sent back by the system")]
        public void ThenCsioNETSessionIDIsSentBackByTheSystem()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("Response").Element("Status").Value);
            sessionGUID = parsedResponse.Element("Response").Element("SessionGUID").Value;
            userGUID = parsedResponse.Element("Response").Element("UserGUID").Value;
        }

        [When(@"Users sends request to get CsioNET messages with following data")]
        public void WhenUsersSendsRequestToGetCsioNETMessagesWithFollowingData(Table table)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getCSIONetMessagesListXML(sessionGUID, userGUID, table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"List of CsioNET messages is sent")]
        public void ThenListOfCsioNETMessagesIsSent()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("Response").Element("Status").Value);
        }

        [When(@"User sends request to get '(.*)' message from obtained list")]
        public void WhenUserSendsRequestToGetMessageFromObtainedList(int messageNo)
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            IEnumerable<XElement> messages = parsedResponse.Element("Response").Elements("Message");
            String messageGUID = messages.ElementAt(messageNo).Element("MessageGUID").Value;
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getCSIONetRetrieveMessageXML(sessionGUID, userGUID, messageGUID), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Message details are sent by CsioNET system")]
        public void ThenMessageDetailsAreSentByCsioNETSystem()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("Response").Element("Status").Value);
        }

        [When(@"User logs out from CsioNET")]
        public void WhenUserLogsOutFromCsioNET()
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/xml");
            request.AddParameter("application/xml", PayloadGenerator.getCSIONetLogoutXML(sessionGUID), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"CsioNET sessionID is closed")]
        public void ThenCsioNETSessionIDIsClosed()
        {
            XDocument parsedResponse = XDocument.Parse(response.Content);
            Assert.AreEqual("Success", parsedResponse.Element("Response").Element("Status").Value);
        }


    }
}
