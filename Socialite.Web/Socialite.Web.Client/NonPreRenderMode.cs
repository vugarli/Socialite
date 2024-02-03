using Microsoft.AspNetCore.Components.Web;
using System.Runtime.CompilerServices;

namespace Socialite.Web.Client
{
    public class NonPreRenderMode : InteractiveWebAssemblyRenderMode
    {
        public NonPreRenderMode()
            :base(prerender: false)
        {
            
        }
    }
}
