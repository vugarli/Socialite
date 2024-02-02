using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Identity
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string userName) : base($"User with {userName} not found!")
        {
            
        }
    }
}
