using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialite.Application.Services.Auth;
using Socialite.Infrastructure.Identity;

namespace Socialite.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Secured : ControllerBase
    {
        public Secured(ICurrentUserService currentUserService)
        {
            CurrentUserService = currentUserService;
        }

        public ICurrentUserService CurrentUserService { get; }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok($"You have made it! {CurrentUserService.GetCurrentUserId()}");
        }

    }
}
