﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace specflowPoC.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("API integration")]
    public partial class APIIntegrationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "IntegrationAPI.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "API integration", "  As a User I want to verify API calculations", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01. Verify simple user Flow Induced Excitation successful calculation")]
        [NUnit.Framework.TestCaseAttribute("1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", null)]
        [NUnit.Framework.TestCaseAttribute("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", null)]
        [NUnit.Framework.TestCaseAttribute("136", "5", "0.001", "0.152", "0", "977", "286", "601", "12", "1", "3800000", null)]
        [NUnit.Framework.TestCaseAttribute("136", "5", "0.001", "0.153", "0", "977", "285", "601", "12", "1", "3800000", null)]
        [NUnit.Framework.TestCaseAttribute("136", "10", "0.001", "0.153", "0", "977", "280", "601", "12", "1", "3800000", null)]
        [NUnit.Framework.TestCaseAttribute("136", "10", "0.001", "0.153", "0", "977", "280", "601", "12", "1", "3800000", null)]
        [NUnit.Framework.TestCaseAttribute("50", "45", "0.09", "0.15", "0.015", "794", "1500", "1500", "20", "1.5", "4200000", null)]
        public virtual void _01_VerifySimpleUserFlowInducedExcitationSuccessfulCalculation(string insDiam, string len, string waterFR, string gasFR, string oilFR, string waterDen, string gasDen, string oilDen, string branchID, string gasVis, string soundSpeed, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01. Verify simple user Flow Induced Excitation successful calculation", exampleTags);
#line 4
 this.ScenarioSetup(scenarioInfo);
#line 5
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "insideDiameter",
                        "length",
                        "waterFlowRate",
                        "gasFlowRate",
                        "oilFlowRate",
                        "waterDensity",
                        "gasDensity",
                        "oilDensity",
                        "mainBranchID",
                        "gasViscosity",
                        "speedOfSound"});
            table1.AddRow(new string[] {
                        string.Format("{0}", insDiam),
                        string.Format("{0}", len),
                        string.Format("{0}", waterFR),
                        string.Format("{0}", gasFR),
                        string.Format("{0}", oilFR),
                        string.Format("{0}", waterDen),
                        string.Format("{0}", gasDen),
                        string.Format("{0}", oilDen),
                        string.Format("{0}", branchID),
                        string.Format("{0}", gasVis),
                        string.Format("{0}", soundSpeed)});
#line 6
  testRunner.When("User sends API request to calculate FIE parameters with following data", ((string)(null)), table1, "When ");
#line 9
  testRunner.Then("FIE parameters are calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. Verify simple user Flow Induced Turbulence successful calculation")]
        [NUnit.Framework.TestCaseAttribute("1", "1", "1", "1", "1", "1", "1", "1", "1", "1", null)]
        [NUnit.Framework.TestCaseAttribute("0", "0", "0", "0", "0", "0", "0", "0", "0", "0", null)]
        [NUnit.Framework.TestCaseAttribute("-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", "-1", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.152", "0", "219", "136", "5", "977", "286", "601", "3", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.162", "0", "219", "136", "5", "977", "276", "601", "3", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.172", "0", "219", "136", "5", "977", "266", "601", "3", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.182", "0", "219", "136", "5", "977", "256", "601", "3", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.192", "0", "219", "136", "5", "977", "246", "601", "3", null)]
        [NUnit.Framework.TestCaseAttribute("0.001", "0.200", "0", "94", "12", "1000", "977", "246", "601", "3", null)]
        public virtual void _02_VerifySimpleUserFlowInducedTurbulenceSuccessfulCalculation(string waterFR, string gasFR, string oilFR, string pipeOutsideDiam, string pipeInsideDiam, string pipeLength, string waterDen, string gasDen, string oilDen, string gasVis, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify simple user Flow Induced Turbulence successful calculation", exampleTags);
#line 22
 this.ScenarioSetup(scenarioInfo);
#line 23
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "waterFlowRate",
                        "gasFlowRate",
                        "oilFlowRate",
                        "mainPipeOutsideDiameter",
                        "mainPipeInsideDiameter",
                        "mainPipeSpanLength",
                        "waterDensity",
                        "gasDensity",
                        "oilDensity",
                        "gasViscosity"});
            table2.AddRow(new string[] {
                        string.Format("{0}", waterFR),
                        string.Format("{0}", gasFR),
                        string.Format("{0}", oilFR),
                        string.Format("{0}", pipeOutsideDiam),
                        string.Format("{0}", pipeInsideDiam),
                        string.Format("{0}", pipeLength),
                        string.Format("{0}", waterDen),
                        string.Format("{0}", gasDen),
                        string.Format("{0}", oilDen),
                        string.Format("{0}", gasVis)});
#line 24
  testRunner.When("User sends API request to calculate FIT parameters with following data", ((string)(null)), table2, "When ");
#line 27
  testRunner.Then("FIT parameters are calculated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. Wrong file upload verification")]
        [NUnit.Framework.TestCaseAttribute("alpaca26kb.jpg", "Invalid PVT file format", null)]
        public virtual void _03_WrongFileUploadVerification(string fileName, string message, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. Wrong file upload verification", exampleTags);
#line 41
 this.ScenarioSetup(scenarioInfo);
#line 42
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
  testRunner.When(string.Format("User sends API request to upload {0} file", fileName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
  testRunner.Then(string.Format("Proper error message {0} is returned", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. User is able to upload PVT file")]
        [NUnit.Framework.TestCaseAttribute("PVT_correctSmall.tab", null)]
        public virtual void _04_UserIsAbleToUploadPVTFile(string fileName, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. User is able to upload PVT file", exampleTags);
#line 50
 this.ScenarioSetup(scenarioInfo);
#line 51
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
  testRunner.When(string.Format("User sends API request to upload {0} file", fileName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
  testRunner.Then("File is uploaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. User is able to create new project")]
        [NUnit.Framework.TestCaseAttribute("PVT_correctSmall.tab", "apiTest", "some description", "3", "2", "2", null)]
        public virtual void _05_UserIsAbleToCreateNewProject(string pvtFileName, string name, string desc, string caseNo, string noOfEquip, string noOfSubEquip, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. User is able to create new project", exampleTags);
#line 59
 this.ScenarioSetup(scenarioInfo);
#line 60
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "fileName",
                        "name",
                        "description",
                        "numberOfCases",
                        "equipments",
                        "subEquipments"});
            table3.AddRow(new string[] {
                        string.Format("{0}", pvtFileName),
                        string.Format("{0}", name),
                        string.Format("{0}", desc),
                        string.Format("{0}", caseNo),
                        string.Format("{0}", noOfEquip),
                        string.Format("{0}", noOfSubEquip)});
#line 61
  testRunner.When("User creates project with given data", ((string)(null)), table3, "When ");
#line 64
  testRunner.Then("Project is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. User is able to get list of created projects")]
        public virtual void _06_UserIsAbleToGetListOfCreatedProjects()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. User is able to get list of created projects", ((string[])(null)));
#line 70
 this.ScenarioSetup(scenarioInfo);
#line 71
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
  testRunner.When("User sends API request to get list of created projects", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
  testRunner.Then("List of projects is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("07. User is able to get details of given project")]
        public virtual void _07_UserIsAbleToGetDetailsOfGivenProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("07. User is able to get details of given project", ((string[])(null)));
#line 75
 this.ScenarioSetup(scenarioInfo);
#line 76
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
  testRunner.When("User sends API request to get project details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
  testRunner.Then("Project details are returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
  testRunner.Then("Project has 2 added equipments", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("08. User is able to update aspects details of given project")]
        [NUnit.Framework.TestCaseAttribute("1000", "module should be checked", "false", "", "false", "", "false", "", "false", "", null)]
        public virtual void _08_UserIsAbleToUpdateAspectsDetailsOfGivenProject(string maxKinEnergy, string maxKinComment, string mod27, string mod27_Comment, string mod29, string mod29_Comment, string mod28, string mod28_Comment, string mod4, string mod4_Comment, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("08. User is able to update aspects details of given project", exampleTags);
#line 81
 this.ScenarioSetup(scenarioInfo);
#line 82
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "maxKineticEnergy",
                        "maxKineticEnergyComment",
                        "module2_7Enabled",
                        "module2_7Comment",
                        "module2_9Enabled",
                        "module2_9Comment",
                        "module2_8Enabled",
                        "module2_8Comment",
                        "module4Enabled",
                        "module4Comment"});
            table4.AddRow(new string[] {
                        string.Format("{0}", maxKinEnergy),
                        string.Format("{0}", maxKinComment),
                        string.Format("{0}", mod27),
                        string.Format("{0}", mod27_Comment),
                        string.Format("{0}", mod29),
                        string.Format("{0}", mod29_Comment),
                        string.Format("{0}", mod28),
                        string.Format("{0}", mod28_Comment),
                        string.Format("{0}", mod4),
                        string.Format("{0}", mod4_Comment)});
#line 83
  testRunner.When("User send API request to update aspects details of given project", ((string)(null)), table4, "When ");
#line 86
  testRunner.Then("Aspects details are updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("09. User is able to get aspects details of given project")]
        public virtual void _09_UserIsAbleToGetAspectsDetailsOfGivenProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("09. User is able to get aspects details of given project", ((string[])(null)));
#line 92
 this.ScenarioSetup(scenarioInfo);
#line 93
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 94
  testRunner.When("User send API request to get aspects details of given project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
  testRunner.Then("Aspects details are returned with Max kinetic energy set to 1000.0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("10. User is able to get precalc info about given equipment within created project" +
            "")]
        public virtual void _10_UserIsAbleToGetPrecalcInfoAboutGivenEquipmentWithinCreatedProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("10. User is able to get precalc info about given equipment within created project" +
                    "", ((string[])(null)));
#line 97
 this.ScenarioSetup(scenarioInfo);
#line 98
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
  testRunner.When("User sends API request to get precalc info", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
  testRunner.Then("Precalc info is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("11. User is able to update precalc info for given equipment within created projec" +
            "t")]
        [NUnit.Framework.TestCaseAttribute("100.0", "123.0", "10.0", "20.1", "123.3", "23.4", "34.5", "34.5", null)]
        public virtual void _11_UserIsAbleToUpdatePrecalcInfoForGivenEquipmentWithinCreatedProject(string gasDensity, string oilDensity, string waterDensity, string press, string temp, string gasRate, string oilRate, string waterRate, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("11. User is able to update precalc info for given equipment within created projec" +
                    "t", exampleTags);
#line 102
 this.ScenarioSetup(scenarioInfo);
#line 103
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "standardGasDensity",
                        "standardOilDensity",
                        "standardWaterDensity",
                        "pressure",
                        "temperature",
                        "gasRateAtStandardConditions",
                        "oilRateAtStandardConditions",
                        "waterRateAtStandardConditions"});
            table5.AddRow(new string[] {
                        string.Format("{0}", gasDensity),
                        string.Format("{0}", oilDensity),
                        string.Format("{0}", waterDensity),
                        string.Format("{0}", press),
                        string.Format("{0}", temp),
                        string.Format("{0}", gasRate),
                        string.Format("{0}", oilRate),
                        string.Format("{0}", waterRate)});
#line 104
  testRunner.When("User send API request to update precalc info with given data", ((string)(null)), table5, "When ");
#line 107
  testRunner.Then("Precalc info is updated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("12. User is able to get Module-2.2 data for given equipment within created projec" +
            "t")]
        public virtual void _12_UserIsAbleToGetModule_2_2DataForGivenEquipmentWithinCreatedProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("12. User is able to get Module-2.2 data for given equipment within created projec" +
                    "t", ((string[])(null)));
#line 113
 this.ScenarioSetup(scenarioInfo);
#line 114
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 115
  testRunner.When("User sends API request to get Module-2.2 details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
  testRunner.Then("Module-2.2 details are returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("13. User is able to delete uploaded PVT file")]
        public virtual void _13_UserIsAbleToDeleteUploadedPVTFile()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("13. User is able to delete uploaded PVT file", ((string[])(null)));
#line 118
 this.ScenarioSetup(scenarioInfo);
#line 119
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 120
  testRunner.When("User sends API request to delete uploaded PVT file", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
  testRunner.Then("PVT file is deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("14. User is able to delete given project")]
        public virtual void _14_UserIsAbleToDeleteGivenProject()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("14. User is able to delete given project", ((string[])(null)));
#line 123
 this.ScenarioSetup(scenarioInfo);
#line 124
  testRunner.Given("Application API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 125
  testRunner.When("User sends API request to delete given project", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
  testRunner.Then("Project is deleted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
