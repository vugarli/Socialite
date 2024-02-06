using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

using Socialite.Application.Exceptions.Auth;
using Socialite.Application.Requests.Auth;
using Socialite.Application.Responses.Auth;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Abstract.Identity;
using Socialite.Infrastructure.Identity;

namespace Socialite.Api.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : RESTFulController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenClaimsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthenticationService _authenticationService;

        public AuthController(SignInManager<ApplicationUser> signInManager,
            ITokenService tokenClaimsService,
            UserManager<ApplicationUser> userManager,IAuthenticationService authenticationService)
        {
            _signInManager = signInManager;
            _tokenClaimsService = tokenClaimsService;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginDto loginDto)
        {
            try 
            {
                var authResponse = await _authenticationService.LoginAsync(loginDto);
                return Ok(authResponse);
            }
            catch (AuthenticationValidationException validationException) 
            {
                return BadRequest(validationException);
            }
            catch(Exception ex) 
            {
                return InternalServerError("Something bad happened, contact support!");
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(
            [FromBody] RegisterDto registerDto)
        {
            try
            {
                await _authenticationService.RegisterAsync(registerDto);
                return Ok();
            }
            catch (AuthenticationValidationException validationException)
            {
                return BadRequest(validationException);
            }
            catch (Exception ex)
            {
                return InternalServerError("Something bad happened, contact support!");
            }
        }




    }
}
