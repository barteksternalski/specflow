using System;
using RestSharp;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace specflowPoC
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    

    [Binding]
    public class SimpleAPITestSteps
    {
        RestClient client = new RestClient();
        RestRequest request = new RestRequest();
        IRestResponse response = new RestResponse();
        List<User> userList = new List<User>();

        [Given(@"Service ""(.*)"" is up and running")]
        public void GivenServiceIsUpAndRunning(string serviceRoot)
        {
            client.BaseUrl = new Uri(serviceRoot);
        }
        
        [When(@"I request list of users")]
        public void WhenIRequestCurrentVersionWithEndpoint()
        {
            request = new RestRequest("/users", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }
        
        [Then(@"No of users is (.+)")]
        public void ThenIGetTheCurrentServiceVersion(int count)
        {
            userList = JsonConvert.DeserializeObject<List<User>>(response.Content);
            Assert.AreEqual(count, userList.Count);
        }

        [When(@"I create new user with following data")]
        public void WhenICreateNewUserWithFollowingData(Table table)
        {
            dynamic userData = table.CreateDynamicInstance();
            
            User newUser = new User();
            newUser.Id = userData.Id.ToString();
            newUser.Name = userData.Name;
            newUser.Location = userData.Location;

            request = new RestRequest("/users", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("id", newUser.Id);
            request.AddParameter("name", newUser.Name);
            request.AddParameter("location", newUser.Location);
            response = client.Execute(request);
        }

        [Then(@"User is created")]
        public void ThenUserIsCreated()
        {
            Console.Write(response.Content);
        }

    }
}
