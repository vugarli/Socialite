using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace Socialite.Application.Exceptions
{
    public class ImpressionValidationException : Xeption
    {
        public ImpressionValidationException()
            : base("Impression validation failed see errors for details")
        {
            
        }
        public ImpressionValidationException(Exception exception)
            : base("Impression validation failed see errors for details",exception)
        {
            
        }
    }
}
