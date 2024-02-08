using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException()
            :base("Post with specified Id not found")
        {
            
        }
    }
}
