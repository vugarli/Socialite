using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Domain.Abstract.Identity
{
    public interface ITokenService
    {
        Task<string> GetTokenAsync(string userName);
    }
}
