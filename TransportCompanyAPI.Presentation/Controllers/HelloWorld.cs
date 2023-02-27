using Microsoft.AspNetCore.Mvc;

namespace TransportCompanyAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet(Name = "HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}