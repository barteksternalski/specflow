using System;
using RestSharp;
using TechTalk.SpecFlow;
using specflowPoC.Helpers;
using specflowPoC.TestDataObjects;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Reflection;

namespace specflowPoC.StepsUI
{
    [Binding]
    class IntegrationAPISteps
    {
        static IRestClient client = new RestClient();
        static IRestResponse response;
        static long projectId = 0;
        static long pvtFileId = 0;

        [Given(@"Application API is up and running")]
        public void GivenApplicationAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("https://fiv-dev-api-dot-nice-unison-194320.appspot.com");
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
            Console.WriteLine("LoF: " + results.result.likelihoodOfFailure);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "Response message: " + response.Content);
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
            Console.WriteLine("LoF: " + results.result.likelihoodOfFailure);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to get list of created projects")]
        public void WhenUserSendsAPIRequestToGetListOfCreatedProjects()
        {
            RestRequest request = new RestRequest("/api/project", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"List of projects is returned")]
        public void ThenListOfProjectsIsReturned()
        {
            GetListOfProjectsObject projectsList = JsonConvert.DeserializeObject<GetListOfProjectsObject>(response.Content);
            Console.WriteLine("No of projects: " + projectsList.projects.Count);
            Assert.GreaterOrEqual(projectsList.projects.Count, 1);
        }

        [When(@"User sends API request to get project details")]
        public void WhenUserSendsAPIRequestToGetDetailsOfProject()
        {
            RestRequest request = new RestRequest("/api/project/" + projectId.ToString(), Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Project details are returned")]
        public void ThenProjectDetailsAreReturned()
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(response.Content);
            Console.WriteLine("Project name: " + projectDetails.project.name);
            Assert.NotNull(projectDetails.project.name);
        }

        [Then(@"Project has (.*) added equipments")]
        public void ThenProjectHasAddedEquipments(int equipmentCount)
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(response.Content);
            Assert.Equals(projectDetails.project.equipments.Count, equipmentCount);
        }


        [When(@"User creates project with given data")]
        public void WhenUserCreatesProjectWithGivenData(Table table)
        {
            RestRequest request = new RestRequest("/api/project", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getNewProjectPayload(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Project is created")]
        public void ThenProjectIsCreated()
        {
            CreateProjectResponsePayloadObject newProjectInfo = JsonConvert.DeserializeObject<CreateProjectResponsePayloadObject>(response.Content);
            Console.WriteLine("Project id: " + newProjectInfo.id);
            projectId = newProjectInfo.id;
            Assert.NotNull(newProjectInfo.id);
        }

        [When(@"User send API request to get aspects details of given project")]
        public void WhenUserSendAPIRequestToGetAspectsDetailsOfGivenProject()
        {
            RestRequest request = new RestRequest("/api/project/" + projectId.ToString() + "/aspects", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Aspects details are returned with Max kinetic energy set to (.*)")]
        public void ThenAspectsDetailsAreReturnedWithMaxKineticEnergySetTo(double maxKinEnergyValue)
        {
            AspectsDetailsObject aspectsDetails = JsonConvert.DeserializeObject<AspectsDetailsObject>(response.Content);
            Assert.AreEqual(maxKinEnergyValue, aspectsDetails.aspects.maxKineticEnergy);
        }

        [When(@"User send API request to update aspects details of given project")]
        public void WhenUserSendAPIRequestToUpdateAspectsDetailsOfGivenProject(Table table)
        {
            RestRequest request = new RestRequest("/api/project/" + projectId.ToString() + "/aspects", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getAspectsDetailsPayload(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Aspects details are updated")]
        public void ThenAspectsDetailsAreUpdated()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to delete given project")]
        public void WhenUserSendsAPIRequestToDeleteGivenProject()
        {
            RestRequest request = new RestRequest("/api/project/" + projectId.ToString(), Method.DELETE);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Project is deleted")]
        public void ThenProjectIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [When(@"User sends API request to upload (.*) file")]
        public void WhenUserSendsAPIRequestToUploadPVTFile(String fileName)
        {
            RestRequest request = new RestRequest("/api/pvt/upload", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddFile("file", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestFiles\" + fileName));
            response = client.Execute(request);
        }

        [Then(@"File is uploaded")]
        public void ThenFileIsUploaded()
        {
            PVTFileObject pvtFile = JsonConvert.DeserializeObject<PVTFileObject>(response.Content);
            Console.WriteLine("PVT file id: " + pvtFile.pvtDataId);
            projectId = pvtFile.pvtDataId;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Then(@"Proper error message (.+) is returned")]
        public void ThenProperErrorMessageInvalidPVTFileFormat_IsReturned(String errorMessage)
        {
            GeneralErrorHandlingObject error = JsonConvert.DeserializeObject<GeneralErrorHandlingObject>(response.Content);
            Assert.AreEqual(errorMessage, error.message);
        }

        [When(@"User sends API request to delete uploaded PVT file")]
        public void WhenUserSendsAPIRequestToDeleteUploadedPVTFile()
        {
            RestRequest request = new RestRequest("/api/pvt/delete", Method.DELETE);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getDeletePVTFilePayload(5740087962763264), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"PVT file is deleted")]
        public void ThenPVTFileIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
