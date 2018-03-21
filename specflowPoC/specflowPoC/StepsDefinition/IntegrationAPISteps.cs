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
using AventStack.ExtentReports;

namespace specflowPoC.StepsUI
{
    [Binding]
    class IntegrationAPISteps
    {
        static IRestClient client = new RestClient();
        static IRestResponse response;
        static long projectId = 0;
        static long pvtFileId = 0;
        static string equipmentId = "";

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
            TestContext.WriteLine("Response: " + response.Content);
            FIEResponsePayloadObject results = JsonConvert.DeserializeObject<FIEResponsePayloadObject>(response.Content);
            TestContext.WriteLine("LoF: " + results.result.likelihoodOfFailure);
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
            TestContext.WriteLine("Response: " + response.Content);
            FITResponsePayloadObject results = JsonConvert.DeserializeObject<FITResponsePayloadObject>(response.Content);
            TestContext.WriteLine("LoF: " + results.result.likelihoodOfFailure);
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
            TestContext.WriteLine("Response: " + response.Content);
            GetListOfProjectsObject projectsList = JsonConvert.DeserializeObject<GetListOfProjectsObject>(response.Content);
            TestContext.WriteLine("No of projects: " + projectsList.projects.Count);
            Assert.GreaterOrEqual(projectsList.projects.Count, 1);
        }

        [When(@"User sends API request to get project details")]
        public void WhenUserSendsAPIRequestToGetDetailsOfProject()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Project details are returned")]
        public void ThenProjectDetailsAreReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(response.Content);
            TestContext.WriteLine("Project name: " + projectDetails.project.name);
            Assert.NotNull(projectDetails.project.name);
        }

        [Then(@"Project has (.*) added equipments")]
        public void ThenProjectHasAddedEquipments(int equipmentCount)
        {
            TestContext.WriteLine("Response: " + response.Content);
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(response.Content);
            equipmentId = projectDetails.project.equipment[0].subEquipment[0].id;
            Assert.AreEqual(projectDetails.project.equipment.Count, equipmentCount);
        }


        [When(@"User creates project with given data")]
        public void WhenUserCreatesProjectWithGivenData(Table table)
        {
            RestRequest request = new RestRequest("/api/project", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getNewProjectPayload(table, pvtFileId), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Project is created")]
        public void ThenProjectIsCreated()
        {
            TestContext.WriteLine("Response: " + response.Content);
            CreateProjectResponsePayloadObject newProjectInfo = JsonConvert.DeserializeObject<CreateProjectResponsePayloadObject>(response.Content);
            TestContext.WriteLine("Project id: " + newProjectInfo.id);
            projectId = newProjectInfo.id;
            Assert.NotNull(newProjectInfo.id);
        }

        [When(@"User send API request to get aspects details of given project")]
        public void WhenUserSendAPIRequestToGetAspectsDetailsOfGivenProject()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/aspects", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Aspects details are returned with Max kinetic energy set to (.*)")]
        public void ThenAspectsDetailsAreReturnedWithMaxKineticEnergySetTo(double maxKinEnergyValue)
        {
            TestContext.WriteLine("Response: " + response.Content);
            AspectsDetailsObject aspectsDetails = JsonConvert.DeserializeObject<AspectsDetailsObject>(response.Content);
            Assert.AreEqual(maxKinEnergyValue, aspectsDetails.aspects.maxKineticEnergy);
        }

        [When(@"User send API request to update aspects details of given project")]
        public void WhenUserSendAPIRequestToUpdateAspectsDetailsOfGivenProject(Table table)
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/aspects", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getAspectsDetailsPayload(table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Aspects details are updated")]
        public void ThenAspectsDetailsAreUpdated()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to delete given project")]
        public void WhenUserSendsAPIRequestToDeleteGivenProject()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}", Method.DELETE);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Project is deleted")]
        public void ThenProjectIsDeleted()
        {
            TestContext.WriteLine("Response: " + response.Content);
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
            TestContext.WriteLine("Response: " + response.Content);
            PVTFileObject pvtFile = JsonConvert.DeserializeObject<PVTFileObject>(response.Content);
            TestContext.WriteLine("PVT file id: " + pvtFile.pvtDataId);
            pvtFileId = pvtFile.pvtDataId;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Then(@"Proper error message (.+) is returned")]
        public void ThenProperErrorMessageInvalidPVTFileFormat_IsReturned(String errorMessage)
        {
            TestContext.WriteLine("Response: " + response.Content);
            GeneralErrorHandlingObject error = JsonConvert.DeserializeObject<GeneralErrorHandlingObject>(response.Content);
            Assert.AreEqual(errorMessage, error.message);
        }

        [When(@"User sends API request to delete uploaded PVT file")]
        public void WhenUserSendsAPIRequestToDeleteUploadedPVTFile()
        {
            RestRequest request = new RestRequest("/api/pvt/delete", Method.DELETE);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getDeletePVTFilePayload(pvtFileId), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"PVT file is deleted")]
        public void ThenPVTFileIsDeleted()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to get precalc info")]
        public void WhenUserSendsAPIRequestToGetPrecalcInfo()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/precalc/{equipmentId}", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Precalc info is returned")]
        public void ThenPrecalcInfoIsReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User send API request to update precalc info with given data")]
        public void WhenUserSendAPIRequestToUpdatePrecalcInfoWithGivenData(Table table)
        {
            PrecalcDetailsObject _precalc = JsonConvert.DeserializeObject<PrecalcDetailsObject>(response.Content);

            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/precalc/{equipmentId}", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", PayloadGenerator.getPrecalcDetailsPayload(_precalc), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Precalc info is updated")]
        public void ThenPrecalcInfoIsUpdated()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 details")]
        public void WhenUserSendsAPIRequestToGetModule22Details()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module22/{equipmentId}", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Module-2.2 details are returned")]
        public void ThenModule22DetailsAreReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.2 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule22DetailsWithGivenData(Table table)
        {
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(response.Content);
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module22/{equipmentId}", Method.PUT);
            request.AddParameter("application/json", PayloadGenerator.getModule22UpdatePayload(details, table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Module-2.2 details are updated")]
        public void ThenModule22DetailsAreUpdated()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Module22ResultsObject details = JsonConvert.DeserializeObject<Module22ResultsObject>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule22LoFInfo()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module22/{equipmentId}/lof", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Module-2.2 LoF info is returned")]
        public void ThenModule22LoFInfoIsReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Module22LoFObject details = JsonConvert.DeserializeObject<Module22LoFObject>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }

        [When(@"User sends API request to get Module-2.6 details")]
        public void WhenUserSendsAPIRequestToGetModule26Details()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module26/{equipmentId}", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Module-2.6 details are returned")]
        public void ThenModule26DetailsAreReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.6 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule26DetailsWithGivenData(Table table)
        {
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(response.Content);
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module26/{equipmentId}", Method.PUT);
            request.AddParameter("application/json", PayloadGenerator.getModule26UpdatePayload(details, table), ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [Then(@"Module-2.6 details are updated")]
        public void ThenModule26DetailsAreUpdated()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Module26ResultsObject details = JsonConvert.DeserializeObject<Module26ResultsObject>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.6 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule26LoFInfo()
        {
            RestRequest request = new RestRequest($"/api/project/{projectId.ToString()}/module26/{equipmentId}/lof", Method.GET);
            request.AddHeader("Accept", "application/json");
            response = client.Execute(request);
        }

        [Then(@"Module-2.6 LoF info is returned")]
        public void ThenModule26LoFInfoIsReturned()
        {
            TestContext.WriteLine("Response: " + response.Content);
            Module26LoFObject details = JsonConvert.DeserializeObject<Module26LoFObject>(response.Content);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }
    }
}
