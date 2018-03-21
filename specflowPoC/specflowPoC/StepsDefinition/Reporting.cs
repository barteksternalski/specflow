using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using specflowPoC.Helpers;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace specflowPoC.StepsDefinition
{
    [Binding]
    class Reporting
    {
        TestUtility utility;
        public Reporting(TestUtility utility)
        {
            this.utility = utility;
        }

        protected static ExtentReports _extent;
        protected static ExtentTest _test;

        [BeforeFeature]
        protected static void Setup()
        {
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestReports\", "Report.html"));

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [AfterFeature]
        protected static void TearDown()
        {
            _extent.Flush();
        }

        [BeforeScenario]
        public void BeforeTest()
        {
            _test = _extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
            _test.Info("Details: " + TestContext.CurrentContext.Test.Name);
        }

        [AfterScenario]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Info("Request: " + utility.request.Resource);
            _test.Info("Response: " + TestUtility.response.Content.ToString());
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }

        [AfterStep]
        public void AfterStep()
        {
            string stepName = ScenarioStepContext.Current.StepInfo.Text;
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType;
            _test.Info($"[{stepType}]: {stepName}");
        }
    }
}
