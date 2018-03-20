using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace specflowPoC.StepsDefinition
{
    [Binding]
    public class Reporting
    {
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
        public static void BeforeTest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [AfterScenario]
        public static void AfterTest()
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

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }
    }
}
