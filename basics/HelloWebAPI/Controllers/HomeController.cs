using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public String GetMessage()
        {
            return "Hello ASP.Net Core Web Api";
        }
    }
}
