using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

[TestFixture]
public class SeleniumTests
{
    private IWebDriver? _driver;
    private ExtentReports? _extent;
    private ExtentTest? _test;

    [OneTimeSetUp]
    public void Setup()
    {
        var sparkReporter = new ExtentSparkReporter("TestResults.html");
        _extent = new ExtentReports();
        _extent.AttachReporter(sparkReporter);
    }

    [SetUp]
    public void Init()
    {
        var options = new ChromeOptions();
        options.AddArgument("no-sandbox");

        _driver = new RemoteWebDriver(new Uri("http://selenium-hub:4444/wd/hub"), options);
        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
    }

    [Test]
    public void Test_HelloWorld()
    {
        try
        {
            _driver?.Navigate().GoToUrl("http://sample-dotnet-app:8080");
            Assert.That(_driver?.PageSource, Does.Contain("Hello, world!"));
            _test?.Pass("Test_HelloWorld passed.");
        }
        catch (Exception ex)
        {
            _test?.Fail(ex.Message);
            throw;
        }
    }

    [TearDown]
    public void Cleanup()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _extent?.Flush();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _extent?.Flush();
    }
}
