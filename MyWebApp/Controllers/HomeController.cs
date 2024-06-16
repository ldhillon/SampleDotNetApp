using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Hello from MyWebApp!");
}
