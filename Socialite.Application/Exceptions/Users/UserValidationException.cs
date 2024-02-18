using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Socialite.Application.Exceptions.Users
{
    public class UserValidationException : Xeption
    {
        public UserValidationException()
        {

        }

        public UserValidationException(Exception innerException)
            : base("User validation failed see errors for details.", innerException) { }

    }
}
