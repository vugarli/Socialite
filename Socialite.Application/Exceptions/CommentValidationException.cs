using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Socialite.Application.Exceptions
{
    public class CommentValidationException : Xeption
    {
        public CommentValidationException()
        {
            
        }
        public CommentValidationException(Exception exception)
            : base("Comment validaiton failed see errors for details") { }
    }
}
