using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Socialite.Infrastructure.Identity;

namespace Socialite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
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


        



    }
}
