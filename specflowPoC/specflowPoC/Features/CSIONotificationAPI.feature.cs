﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CsioNET integration")]
    public partial class CsioNETIntegrationFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CSIONotificationAPI.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CsioNET integration", "  As a User I want to integrate properly with CsioNET", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("01. Verify unsuccessful sign in request to CsioNET")]
        [NUnit.Framework.CategoryAttribute("CsioNET")]
        [NUnit.Framework.TestCaseAttribute("SignIn", "avanade@vendor.edi.csio.comX", "r49M5VTT", "Failed to sign in this user", null)]
        [NUnit.Framework.TestCaseAttribute("SignIn", "avanade@vendor.edi.csio.com", "X49M5VTT", "Failed to sign in this user", null)]
        public virtual void _01_VerifyUnsuccessfulSignInRequestToCsioNET(string comm, string login, string pass, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CsioNET"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01. Verify unsuccessful sign in request to CsioNET", @__tags);
#line 5
this.ScenarioSetup(scenarioInfo);
#line 6
 testRunner.Given("CsioNET API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "CommandType",
                        "CSIOnetID",
                        "CSIOnetPassword"});
            table1.AddRow(new string[] {
                        string.Format("{0}", comm),
                        string.Format("{0}", login),
                        string.Format("{0}", pass)});
#line 7
 testRunner.When("User sends sign in request to CsioNET with following data", ((string)(null)), table1, "When ");
#line 10
 testRunner.Then(string.Format("CsioNET system responses with proper error \'{0}\'", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02. Verify successful sign in request to CsioNET")]
        [NUnit.Framework.CategoryAttribute("CsioNET")]
        [NUnit.Framework.TestCaseAttribute("SignIn", "dev_avanade@vendor.edi.csio.com", "!F6sxL0v10@4", null)]
        public virtual void _02_VerifySuccessfulSignInRequestToCsioNET(string comm, string login, string pass, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CsioNET"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02. Verify successful sign in request to CsioNET", @__tags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("CsioNET API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "CommandType",
                        "CSIOnetID",
                        "CSIOnetPassword"});
            table2.AddRow(new string[] {
                        string.Format("{0}", comm),
                        string.Format("{0}", login),
                        string.Format("{0}", pass)});
#line 20
 testRunner.When("User sends sign in request to CsioNET with following data", ((string)(null)), table2, "When ");
#line 23
 testRunner.Then("CsioNET sessionID is sent back by the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03. Get list of messages from CsioNET")]
        [NUnit.Framework.CategoryAttribute("CsioNET")]
        [NUnit.Framework.TestCaseAttribute("2018-01-15 00:00:00 AM", "2018-01-20 11:59:59 PM", "1", "10", null)]
        public virtual void _03_GetListOfMessagesFromCsioNET(string from, string to, string page, string items, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CsioNET"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03. Get list of messages from CsioNET", @__tags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("CsioNET API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "FromDateTime",
                        "ToDateTime",
                        "Page",
                        "PageSize"});
            table3.AddRow(new string[] {
                        string.Format("{0}", from),
                        string.Format("{0}", to),
                        string.Format("{0}", page),
                        string.Format("{0}", items)});
#line 32
 testRunner.When("Users sends request to get CsioNET messages with following data", ((string)(null)), table3, "When ");
#line 35
 testRunner.Then("List of CsioNET messages is sent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04. Get single message from CsioNET")]
        [NUnit.Framework.CategoryAttribute("CsioNET")]
        [NUnit.Framework.TestCaseAttribute("1", null)]
        public virtual void _04_GetSingleMessageFromCsioNET(string no, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CsioNET"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04. Get single message from CsioNET", @__tags);
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("CsioNET API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.When(string.Format("User sends request to get \'{0}\' message from obtained list", no), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("Message details are sent by CsioNET system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05. Verify successful logout request from CsioNET")]
        [NUnit.Framework.CategoryAttribute("CsioNET")]
        public virtual void _05_VerifySuccessfulLogoutRequestFromCsioNET()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05. Verify successful logout request from CsioNET", new string[] {
                        "CsioNET"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
 testRunner.Given("CsioNET API is up and running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
 testRunner.When("User logs out from CsioNET", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("CsioNET sessionID is closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
