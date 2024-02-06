using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Socialite.Application.Exceptions.Auth
{
    public class AuthenticationValidationException : Xeption
    {
        public AuthenticationValidationException()
            :base("Authentication problem occured please see the errors!") { }
    }

}
