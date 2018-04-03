using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using specflowPoC.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\TestReports\", "Report.html"));
            htmlReporter.AppendExisting = true;
            htmlReporter.Configuration().DocumentTitle = "SLB OneSubsea";
            htmlReporter.Configuration().ReportName = "API tests";
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

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
            _test.Info("Request: <i>" + utility.request.Resource + "</i>");
            if (utility.requestBody != null) _test.Info("Request body: <pre>" + utility.requestBody + "</pre>");
            _test.Info("Response: <pre>" + utility.response.Content.ToString() + "</pre>");
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }

        [AfterStep]
        public void AfterStep()
        {
            _test.Info($"<b>[{ScenarioStepContext.Current.StepInfo.StepDefinitionType}]</b>: {ScenarioStepContext.Current.StepInfo.Text}");
            if (ScenarioStepContext.Current.StepInfo.Table != null)
            {
                List<List<string>> data = new List<List<string>>();
                data.Add(ScenarioStepContext.Current.StepInfo.Table.Header.ToList());
                data.Add(ScenarioStepContext.Current.StepInfo.Table.Rows[0].Values.ToList());
                IMarkup table = MarkupHelper.CreateTable(data.Select(a => a.ToArray()).ToArray());
                _test.Info(table);
            }            
        }

    }
}
