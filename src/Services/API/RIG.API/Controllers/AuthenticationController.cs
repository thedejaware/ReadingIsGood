using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RIG.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet(Name = "Login")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<object>> Loginn()
        {
            var arr = new string[] { "1", "2" };
            return Ok(arr);
        }
    }
}
