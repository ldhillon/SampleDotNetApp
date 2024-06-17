using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Xunit;

namespace MyWebApp.Tests;

public class HomeTests : IClassFixture<TestFixture>
{
    private readonly RemoteWebDriver _driver;

    public HomeTests(TestFixture fixture)
    {
        _driver = fixture.Driver;
    }

    [Fact]
    public void HomepageShouldReturnHelloMessage()
    {
        _driver.Navigate().GoToUrl("http://mywebapp:80/"); 
        var messageElement = _driver.FindElement(By.TagName("body"));

        Assert.Equal("Hello World!", messageElement.Text);
    }
}

public class TestFixture : IDisposable
{
    public RemoteWebDriver Driver { get; }

    public TestFixture()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless"); 
        Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options); 
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}