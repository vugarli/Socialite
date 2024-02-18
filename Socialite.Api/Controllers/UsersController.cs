using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Socialite.Application.Exceptions;
using Socialite.Application.Exceptions.Users;
using Socialite.Application.Requests.Post;
using Socialite.Application.Services.Auth;
using Socialite.Application.Services.Users;
using Socialite.Common.Endpoints;
using Socialite.Infrastructure.Identity;
using UserNotFoundException = Socialite.Application.Exceptions.Users.UserNotFoundException;

namespace Socialite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : RESTFulController
    {
        private ICurrentUserService _currentUserService { get; }
        public IUsersService _usersService { get; }

        public UsersController(
            ICurrentUserService currentUserService,
            IUsersService usersService
            )
        {
            _currentUserService = currentUserService;
            _usersService = usersService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByIdAsync(int userId)
        {
            return Ok();
        }

        /// <summary>
        /// Non-private posts
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}/posts")]
        public async Task<IActionResult> GetUserPostsAsync(int userId)
        {
            return Ok();
        }

        

        [HttpGet("followers")]
        public async Task<IActionResult> GetFollowers()
        {
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet(UserEndpoints.CurrentUserInfoEndpoint)]
        public async Task<IActionResult> CurrentUserInfoAsync()
        {
            try
            {
                return Ok(await _usersService.GetCurrentUserInfo());
            }
            catch (UserValidationException ex)
                when (ex.InnerException is UserNotFoundException)
            {
                return NotFound(ex);
            }
            catch (UserValidationException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception)
            {
                return InternalServerError("Something bad happened");
            }            
        }

        



    }
}
