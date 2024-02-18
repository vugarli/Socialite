using Socialite.Application.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Users
{
    public interface IUsersService
    {
        public Task<UserInfoDto> GetCurrentUserInfo();
    }
}
