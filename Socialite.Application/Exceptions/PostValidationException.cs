using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Socialite.Application.Exceptions
{
    public class PostValidationException : Xeption
    {
        public PostValidationException()
        {
            
        }

        public PostValidationException(Exception innerException)
            :base("Post validation failed see errors for details.",innerException) { }


    }
}
