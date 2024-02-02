using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialite.Infrastructure.Identity;

namespace Socialite.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Secured : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok("You have made it!");
        }

    }
}
