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
