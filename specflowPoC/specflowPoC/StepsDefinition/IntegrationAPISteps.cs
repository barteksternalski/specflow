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
        IRestClient client = new RestClient();
        TestUtility utility;
        public IntegrationAPISteps(TestUtility utility)
        {
            this.utility = utility;
        }

        [Given(@"Application API is up and running")]
        public void GivenApplicationAPIIsUpAndRunning()
        {
            client.BaseUrl = new Uri("https://fiv-dev-api-dot-nice-unison-194320.appspot.com");
        }

        [When(@"User sends API request to calculate FIE parameters with following data")]
        public void WhenUserSendsAPIRequestToCalculateFIEParametersWithFollowingData(Table table)
        {
            utility.request = new RestRequest("/api/fie/calculate", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getFIERequestPayload(table), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"FIE parameters are calculated")]
        public void ThenFIEParametersAreCalculated()
        {
            FIEResponsePayloadObject results = JsonConvert.DeserializeObject<FIEResponsePayloadObject>(TestUtility.response.Content);
            Assert.IsNotNull(results.result.likelihoodOfFailure);
        }

        [When(@"User sends API request to calculate FIT parameters with following data")]
        public void WhenUserSendsAPIRequestToCalculateFITParametersWithFollowingData(Table table)
        {
            utility.request = new RestRequest("/api/fit/calculate", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getFITRequestPayload(table), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"FIT parameters are calculated")]
        public void ThenFITParametersAreCalculated()
        {
            FITResponsePayloadObject results = JsonConvert.DeserializeObject<FITResponsePayloadObject>(TestUtility.response.Content);
            Assert.IsNotNull(results.result.likelihoodOfFailure);
        }

        [When(@"User sends API request to get list of created projects")]
        public void WhenUserSendsAPIRequestToGetListOfCreatedProjects()
        {
            utility.request = new RestRequest("/api/project", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"List of projects is returned")]
        public void ThenListOfProjectsIsReturned()
        {
            GetListOfProjectsObject projectsList = JsonConvert.DeserializeObject<GetListOfProjectsObject>(TestUtility.response.Content);
            Assert.GreaterOrEqual(projectsList.projects.Count, 1);
        }

        [When(@"User sends API request to get project details")]
        public void WhenUserSendsAPIRequestToGetDetailsOfProject()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Project details are returned")]
        public void ThenProjectDetailsAreReturned()
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(TestUtility.response.Content);
            Assert.NotNull(projectDetails.project.name);
        }

        [Then(@"Project has (.*) added equipments")]
        public void ThenProjectHasAddedEquipments(int equipmentCount)
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(TestUtility.response.Content);
            TestUtility.equipmentId = projectDetails.project.equipment[0].subEquipment[0].id;
            Assert.AreEqual(projectDetails.project.equipment.Count, equipmentCount);
        }


        [When(@"User creates project with given data")]
        public void WhenUserCreatesProjectWithGivenData(Table table)
        {
            utility.request = new RestRequest("/api/project", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getNewProjectPayload(table, TestUtility.pvtFileId), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Project is created")]
        public void ThenProjectIsCreated()
        {
            CreateProjectResponsePayloadObject newProjectInfo = JsonConvert.DeserializeObject<CreateProjectResponsePayloadObject>(TestUtility.response.Content);
            TestUtility.projectId = newProjectInfo.id;
            Assert.NotNull(newProjectInfo.id);
        }

        [When(@"User send API request to get aspects details of given project")]
        public void WhenUserSendAPIRequestToGetAspectsDetailsOfGivenProject()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/aspects", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Aspects details are returned with Max kinetic energy set to (.*)")]
        public void ThenAspectsDetailsAreReturnedWithMaxKineticEnergySetTo(double maxKinEnergyValue)
        {
            AspectsDetailsObject aspectsDetails = JsonConvert.DeserializeObject<AspectsDetailsObject>(TestUtility.response.Content);
            Assert.AreEqual(maxKinEnergyValue, aspectsDetails.aspects.maxKineticEnergy);
        }

        [When(@"User send API request to update aspects details of given project")]
        public void WhenUserSendAPIRequestToUpdateAspectsDetailsOfGivenProject(Table table)
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/aspects", Method.PUT);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getAspectsDetailsPayload(table), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Aspects details are updated")]
        public void ThenAspectsDetailsAreUpdated()
        {
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to delete given project")]
        public void WhenUserSendsAPIRequestToDeleteGivenProject()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}", Method.DELETE);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Project is deleted")]
        public void ThenProjectIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }
        [When(@"User sends API request to upload (.*) file")]
        public void WhenUserSendsAPIRequestToUploadPVTFile(String fileName)
        {
            utility.request = new RestRequest("/api/pvt/upload", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddFile("file", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestFiles\" + fileName));
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"File is uploaded")]
        public void ThenFileIsUploaded()
        {
            PVTFileObject pvtFile = JsonConvert.DeserializeObject<PVTFileObject>(TestUtility.response.Content);
            TestUtility.pvtFileId = pvtFile.pvtDataId;
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [Then(@"Proper error message (.+) is returned")]
        public void ThenProperErrorMessageInvalidPVTFileFormat_IsReturned(String errorMessage)
        {
            GeneralErrorHandlingObject error = JsonConvert.DeserializeObject<GeneralErrorHandlingObject>(TestUtility.response.Content);
            Assert.AreEqual(errorMessage, error.message);
        }

        [When(@"User sends API request to delete uploaded PVT file")]
        public void WhenUserSendsAPIRequestToDeleteUploadedPVTFile()
        {
            utility.request = new RestRequest("/api/pvt/delete", Method.DELETE);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getDeletePVTFilePayload(TestUtility.pvtFileId), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"PVT file is deleted")]
        public void ThenPVTFileIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to get precalc info")]
        public void WhenUserSendsAPIRequestToGetPrecalcInfo()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/precalc/{TestUtility.equipmentId}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Precalc info is returned")]
        public void ThenPrecalcInfoIsReturned()
        {
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User send API request to update precalc info with given data")]
        public void WhenUserSendAPIRequestToUpdatePrecalcInfoWithGivenData(Table table)
        {
            PrecalcDetailsObject _precalc = JsonConvert.DeserializeObject<PrecalcDetailsObject>(TestUtility.response.Content);

            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/precalc/{TestUtility.equipmentId}", Method.PUT);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddParameter("application/json", PayloadGenerator.getPrecalcDetailsPayload(_precalc), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Precalc info is updated")]
        public void ThenPrecalcInfoIsUpdated()
        {
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 details")]
        public void WhenUserSendsAPIRequestToGetModule22Details()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module22/{TestUtility.equipmentId}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.2 details are returned")]
        public void ThenModule22DetailsAreReturned()
        {
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.2 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule22DetailsWithGivenData(Table table)
        {
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(TestUtility.response.Content);
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module22/{TestUtility.equipmentId}", Method.PUT);
            utility.request.AddParameter("application/json", PayloadGenerator.getModule22UpdatePayload(details, table), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.2 details are updated")]
        public void ThenModule22DetailsAreUpdated()
        {
            Module22ResultsObject details = JsonConvert.DeserializeObject<Module22ResultsObject>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule22LoFInfo()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module22/{TestUtility.equipmentId}/lof", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.2 LoF info is returned")]
        public void ThenModule22LoFInfoIsReturned()
        {
            Module22LoFObject details = JsonConvert.DeserializeObject<Module22LoFObject>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }

        [When(@"User sends API request to get Module-2.6 details")]
        public void WhenUserSendsAPIRequestToGetModule26Details()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module26/{TestUtility.equipmentId}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.6 details are returned")]
        public void ThenModule26DetailsAreReturned()
        {
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.6 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule26DetailsWithGivenData(Table table)
        {
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(TestUtility.response.Content);
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module26/{TestUtility.equipmentId}", Method.PUT);
            utility.request.AddParameter("application/json", PayloadGenerator.getModule26UpdatePayload(details, table), ParameterType.RequestBody);
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.6 details are updated")]
        public void ThenModule26DetailsAreUpdated()
        {
            Module26ResultsObject details = JsonConvert.DeserializeObject<Module26ResultsObject>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.6 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule26LoFInfo()
        {
            utility.request = new RestRequest($"/api/project/{TestUtility.projectId.ToString()}/module26/{TestUtility.equipmentId}/lof", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            TestUtility.response = client.Execute(utility.request);
        }

        [Then(@"Module-2.6 LoF info is returned")]
        public void ThenModule26LoFInfoIsReturned()
        {
            Module26LoFObject details = JsonConvert.DeserializeObject<Module26LoFObject>(TestUtility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, TestUtility.response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }
    }
}
