using Socialite.Application.Exceptions.Users;
using Socialite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Services.Users
{
    public interface IUserValidator
    {
        public void ValidateUserOnGet(User user);
    }

    public class UserValidator : IUserValidator
    {
        public void ValidateUserOnGet(User user)
        {
            if (user == null)
                throw new UserNotFoundException();
        }
    }
}
