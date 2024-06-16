using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace SeleniumTests
{
    public class UnitTest1
    {
        private IWebDriver driver;
        private StreamWriter logWriter;

        [SetUp]
        public void Init()
        {
            var options = new ChromeOptions();
            var uri = new Uri("http://selenium-hub:4444/wd/hub");
            var logFilePath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "test-log.txt");
            logWriter = new StreamWriter(logFilePath, true);
            logWriter.AutoFlush = true;
            logWriter.WriteLine($"Attempting to connect to Selenium Grid at {uri}");

            try
            {
                driver = new RemoteWebDriver(uri, options);
                logWriter.WriteLine("Successfully connected to Selenium Grid");
            }
            catch (Exception ex)
            {
                logWriter.WriteLine($"Failed to connect to Selenium Grid: {ex.Message}");
                throw;
            }
        }

        [Test]
        public void Test_HelloWorld()
        {
            logWriter.WriteLine("Starting Test_HelloWorld");
            driver.Navigate().GoToUrl("http://example.com");
            logWriter.WriteLine("Navigated to http://example.com");
            Assert.AreEqual("Example Domain", driver.Title);
            logWriter.WriteLine("Test_HelloWorld completed successfully");
        }

        [TearDown]
        public void Cleanup()
        {
            logWriter.WriteLine("Cleaning up and closing the browser");
            if (driver != null)
            {
                driver.Quit();
                logWriter.WriteLine("Browser closed successfully");
            }
            else
            {
                logWriter.WriteLine("Driver was null, no browser to close");
            }
            logWriter.Close();
        }
    }
}






// using System;
// using NUnit.Framework;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Remote;
// using AventStack.ExtentReports;
// using AventStack.ExtentReports.Reporter;

// [TestFixture]
// public class SeleniumTests
// {
//     private IWebDriver? _driver;
//     private ExtentReports? _extent;
//     private ExtentTest? _test;

//     [OneTimeSetUp]
//     public void Setup()
//     {
//         var sparkReporter = new ExtentSparkReporter("TestResults.html");
//         _extent = new ExtentReports();
//         _extent.AttachReporter(sparkReporter);
//     }

//     [SetUp]
//     public void Init()
//     {
//         var options = new ChromeOptions();
//         options.AddArgument("no-sandbox");

//         _driver = new RemoteWebDriver(new Uri("http://selenium-hub:4444/wd/hub"), options);
//         _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
//     }

//     [Test]
//     public void Test_HelloWorld()
//     {
//         try
//         {
//             _driver?.Navigate().GoToUrl("http://sample-dotnet-app:8080");
//             Assert.That(_driver?.PageSource, Does.Contain("Hello, world!"));
//             _test?.Pass("Test_HelloWorld passed.");
//         }
//         catch (Exception ex)
//         {
//             _test?.Fail(ex.Message);
//             throw;
//         }
//     }

//     [TearDown]
//     public void Cleanup()
//     {
//         _driver?.Quit();
//         _driver?.Dispose();
//         _extent?.Flush();
//     }

//     [OneTimeTearDown]
//     public void TearDown()
//     {
//         _extent?.Flush();
//     }
// }
