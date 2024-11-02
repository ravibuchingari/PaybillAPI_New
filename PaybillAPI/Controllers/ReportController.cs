using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(ISalesRepository salesRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpGet]
        [Route("gst/returns")]
        public async Task<IActionResult> GetGSTReturns([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await salesRepository.GetGSTReturns(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }
    }
}
