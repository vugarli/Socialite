using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Socialite.Web.Client.Models.Auth;
using Socialite.Web.Client.Services.Authentication;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;

namespace Socialite.Web.Client.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        public LoginModel LoginModel { get; set; } = new();
        public EditForm _editForm { get; set; }

        [Inject]
        IHttpClientFactory _httpClientFactory { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        IAuthenticationServicee AuthenticationService { get; set; }

        HttpClient client;
        protected override Task OnInitializedAsync()
        {
            client = _httpClientFactory.CreateClient("API");
            return base.OnInitializedAsync();
        }

        public async Task Login()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                var result = await AuthenticationService.Login(LoginModel);
                var secretresult = await client.GetStringAsync("/api/Secured/secret");
                var a = 1;
                await AuthStateProvider.GetAuthenticationStateAsync();
            }
        }

    }
}
