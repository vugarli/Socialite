using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Exceptions.Users
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
            : base("User with specified Id not found")
        {

        }
    }
}
