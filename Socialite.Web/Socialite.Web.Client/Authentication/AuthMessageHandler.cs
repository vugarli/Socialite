using Blazored.LocalStorage;
using Socialite.Web.Client.Services.Authentication;
using System.Net;

namespace Socialite.Web.Client.Authentication
{
    public class AuthMessageHandler : DelegatingHandler
    {
        private ILocalStorageService _localStorage { get; }

        public AuthMessageHandler(ILocalStorageService local)
        {
            _localStorage = local;
        }


        protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization", "Bearer "+ await _localStorage.GetItemAsync<string>("token"));
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
