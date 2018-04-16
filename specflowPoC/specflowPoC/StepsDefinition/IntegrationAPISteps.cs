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
            utility.requestBody = PayloadGenerator.getFIERequestPayload(table);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"FIE parameters are calculated")]
        public void ThenFIEParametersAreCalculated()
        {
            FIEResponsePayloadObject results = JsonConvert.DeserializeObject<FIEResponsePayloadObject>(utility.response.Content);
            Assert.IsNotNull(results.result.likelihoodOfFailure);
        }

        [When(@"User sends API request to calculate FIT parameters with following data")]
        public void WhenUserSendsAPIRequestToCalculateFITParametersWithFollowingData(Table table)
        {
            utility.request = new RestRequest("/api/fit/calculate", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.requestBody = PayloadGenerator.getFITRequestPayload(table);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"FIT parameters are calculated")]
        public void ThenFITParametersAreCalculated()
        {
            FITResponsePayloadObject results = JsonConvert.DeserializeObject<FITResponsePayloadObject>(utility.response.Content);
            Assert.IsNotNull(results.result.likelihoodOfFailure);
        }

        [When(@"User sends API request to get list of created projects")]
        public void WhenUserSendsAPIRequestToGetListOfCreatedProjects()
        {
            utility.request = new RestRequest("/api/project", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"List of projects is returned")]
        public void ThenListOfProjectsIsReturned()
        {
            GetListOfProjectsObject projectsList = JsonConvert.DeserializeObject<GetListOfProjectsObject>(utility.response.Content);
            Assert.GreaterOrEqual(projectsList.projects.Count, 1);
        }

        [When(@"User sends API request to get project details")]
        public void WhenUserSendsAPIRequestToGetDetailsOfProject()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Project details are returned")]
        public void ThenProjectDetailsAreReturned()
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(utility.response.Content);
            Assert.NotNull(projectDetails.project.name);
        }

        [Then(@"Project has (.*) added equipments")]
        public void ThenProjectHasAddedEquipments(int equipmentCount)
        {
            GetSingleProjecDetailsObject projectDetails = JsonConvert.DeserializeObject<GetSingleProjecDetailsObject>(utility.response.Content);
            FeatureContext.Current["equipmentID"] = projectDetails.project.equipment[0].subEquipment[0].id;
            Assert.AreEqual(projectDetails.project.equipment.Count, equipmentCount);
        }


        [When(@"User creates project with given data")]
        public void WhenUserCreatesProjectWithGivenData(Table table)
        {
            utility.request = new RestRequest("/api/project", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.requestBody = PayloadGenerator.getNewProjectPayload(table, (long)FeatureContext.Current["pvtFileID"]);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Project is created")]
        public void ThenProjectIsCreated()
        {
            CreateProjectResponsePayloadObject newProjectInfo = JsonConvert.DeserializeObject<CreateProjectResponsePayloadObject>(utility.response.Content);
            FeatureContext.Current["projectID"] = newProjectInfo.id;
            Assert.NotNull(newProjectInfo.id);
        }

        [When(@"User send API request to get aspects details of given project")]
        public void WhenUserSendAPIRequestToGetAspectsDetailsOfGivenProject()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/aspects", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Aspects details are returned with Max kinetic energy set to (.*)")]
        public void ThenAspectsDetailsAreReturnedWithMaxKineticEnergySetTo(double maxKinEnergyValue)
        {
            AspectsDetailsObject aspectsDetails = JsonConvert.DeserializeObject<AspectsDetailsObject>(utility.response.Content);
            Assert.AreEqual(maxKinEnergyValue, aspectsDetails.aspects.maxKineticEnergy);
        }

        [When(@"User send API request to update aspects details of given project")]
        public void WhenUserSendAPIRequestToUpdateAspectsDetailsOfGivenProject(Table table)
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/aspects", Method.PUT);
            utility.request.AddHeader("Accept", "application/json");
            utility.requestBody = PayloadGenerator.getAspectsDetailsPayload(table);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Aspects details are updated")]
        public void ThenAspectsDetailsAreUpdated()
        {
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to delete given project")]
        public void WhenUserSendsAPIRequestToDeleteGivenProject()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}", Method.DELETE);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Project is deleted")]
        public void ThenProjectIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }
        [When(@"User sends API request to upload (.*) file")]
        public void WhenUserSendsAPIRequestToUploadPVTFile(String fileName)
        {
            utility.request = new RestRequest("/api/pvt/upload", Method.POST);
            utility.request.AddHeader("Accept", "application/json");
            utility.request.AddFile("file", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestFiles\" + fileName));
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"File is uploaded")]
        public void ThenFileIsUploaded()
        {
            PVTFileObject pvtFile = JsonConvert.DeserializeObject<PVTFileObject>(utility.response.Content);
            FeatureContext.Current["pvtFileID"] = pvtFile.pvtDataId;
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [Then(@"Proper error message (.*) is returned")]
        public void ThenProperErrorMessageInvalidPVTFileFormat_IsReturned(String errorMessage)
        {
            GeneralErrorHandlingObject error = JsonConvert.DeserializeObject<GeneralErrorHandlingObject>(utility.response.Content);
            Assert.AreEqual(errorMessage, error.message);
        }

        [When(@"User sends API request to delete uploaded PVT file")]
        public void WhenUserSendsAPIRequestToDeleteUploadedPVTFile()
        {
            utility.request = new RestRequest("/api/pvt/delete", Method.DELETE);
            utility.request.AddHeader("Accept", "application/json");
            utility.requestBody = PayloadGenerator.getDeletePVTFilePayload((long)FeatureContext.Current["pvtFileID"]);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"PVT file is deleted")]
        public void ThenPVTFileIsDeleted()
        {
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to get precalc info")]
        public void WhenUserSendsAPIRequestToGetPrecalcInfo()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/precalc/{FeatureContext.Current["equipmentID"]}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Precalc info is returned")]
        public void ThenPrecalcInfoIsReturned()
        {
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User send API request to update precalc info with given data")]
        public void WhenUserSendAPIRequestToUpdatePrecalcInfoWithGivenData(Table table)
        {
            PrecalcDetailsObject _precalc = JsonConvert.DeserializeObject<PrecalcDetailsObject>(((IRestResponse)FeatureContext.Current["response"]).Content);

            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/precalc/{FeatureContext.Current["equipmentID"]}", Method.PUT);
            utility.request.AddHeader("Accept", "application/json");
            utility.requestBody = PayloadGenerator.getPrecalcDetailsPayload(_precalc);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Precalc info is updated")]
        public void ThenPrecalcInfoIsUpdated()
        {
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 details")]
        public void WhenUserSendsAPIRequestToGetModule22Details()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module22/{FeatureContext.Current["equipmentID"]}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.2 details are returned")]
        public void ThenModule22DetailsAreReturned()
        {
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.2 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule22DetailsWithGivenData(Table table)
        {
            GetModule22Object details = JsonConvert.DeserializeObject<GetModule22Object>(((IRestResponse)FeatureContext.Current["response"]).Content);
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module22/{FeatureContext.Current["equipmentID"]}", Method.PUT);
            utility.requestBody = PayloadGenerator.getModule22UpdatePayload(details, table);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.2 details are updated")]
        public void ThenModule22DetailsAreUpdated()
        {
            Module22ResultsObject details = JsonConvert.DeserializeObject<Module22ResultsObject>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.2 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule22LoFInfo()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module22/{FeatureContext.Current["equipmentID"]}/lof", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.2 LoF info is returned")]
        public void ThenModule22LoFInfoIsReturned()
        {
            Module22LoFObject details = JsonConvert.DeserializeObject<Module22LoFObject>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }

        [When(@"User sends API request to get Module-2.6 details")]
        public void WhenUserSendsAPIRequestToGetModule26Details()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module26/{FeatureContext.Current["equipmentID"]}", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.6 details are returned")]
        public void ThenModule26DetailsAreReturned()
        {
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to update Module-2.6 details with given data")]
        public void WhenUserSendsAPIRequestToUpdateModule26DetailsWithGivenData(Table table)
        {
            GetModule26Object details = JsonConvert.DeserializeObject<GetModule26Object>(((IRestResponse)FeatureContext.Current["response"]).Content);
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module26/{FeatureContext.Current["equipmentID"]}", Method.PUT);
            utility.requestBody = PayloadGenerator.getModule26UpdatePayload(details, table);
            utility.request.AddParameter("application/json", utility.requestBody, ParameterType.RequestBody);
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.6 details are updated")]
        public void ThenModule26DetailsAreUpdated()
        {
            Module26ResultsObject details = JsonConvert.DeserializeObject<Module26ResultsObject>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
        }

        [When(@"User sends API request to get Module-2.6 LoF info")]
        public void WhenUserSendsAPIRequestToGetModule26LoFInfo()
        {
            utility.request = new RestRequest($"/api/project/{FeatureContext.Current["projectID"].ToString()}/module26/{FeatureContext.Current["equipmentID"]}/lof", Method.GET);
            utility.request.AddHeader("Accept", "application/json");
            utility.response = client.Execute(utility.request);
            FeatureContext.Current["response"] = utility.response;
        }

        [Then(@"Module-2.6 LoF info is returned")]
        public void ThenModule26LoFInfoIsReturned()
        {
            Module26LoFObject details = JsonConvert.DeserializeObject<Module26LoFObject>(utility.response.Content);
            Assert.AreEqual(HttpStatusCode.OK, utility.response.StatusCode);
            Assert.IsNotNull(details.data.likelihoodOfFailureData.Count);
        }
    }
}
