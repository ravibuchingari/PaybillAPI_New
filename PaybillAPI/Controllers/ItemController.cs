﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
    }
}
