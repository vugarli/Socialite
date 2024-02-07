using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Auth
{
    public interface ICurrentUserService
    {
        public int GetCurrentUserId();
    }
    public class CurrentUserService : ICurrentUserService
    {
        private IHttpContextAccessor _httpContextAccessor { get; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetCurrentUserId()
        {
            var claims = _httpContextAccessor
                .HttpContext?
                .User?.Claims.ToList();

            var userId = claims
                .FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
            return Convert.ToInt32(userId);
        }
    }
}
