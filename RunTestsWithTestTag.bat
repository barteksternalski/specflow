REM
packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe SpecflowTests.nunit /config:Debug --where "cat == Test" --labels=All --out=TestResults\TestResult.txt "--result=TestResults\TestResult.xml;format=nunit2"

REM packages\SpecFlow.2.2.0\tools\specflow.exe nunitexecutionreport Infusion.Specflow.Tests.Template.csproj /xmlTestResult:TestResults\TestResult.xml /out:TestResults\SpecflowResults.html

REM packages\SpecFlow.2.2.0\tools\specflow.exe stepdefinitionreport Infusion.Specflow.Tests.Template.csproj /out:TestResults\StepDefinitionsReport.html