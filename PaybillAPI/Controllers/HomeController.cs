using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaybillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            return Ok("Server is running...");
        }
    }
}
