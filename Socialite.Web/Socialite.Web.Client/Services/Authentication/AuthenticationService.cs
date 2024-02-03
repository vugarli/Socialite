using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Socialite.Web.Client.Models.Auth;
using System.ComponentModel.Design;
using System.Net.Http;
using System.Net.Http.Json;

namespace Socialite.Web.Client.Services.Authentication
{
    public interface IAuthenticationServicee
    {
        Task<string> GetToken();
        Task<bool> Login(LoginModel model);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationServicee
    {
        private HttpClient client;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider customAuthenticationProvider;

        public string Token { get; private set; }

        public AuthenticationService(
            IHttpClientFactory httpClientFactory,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider customAuthenticationProvider
        )
        {
            client = httpClientFactory.CreateClient("Auth");
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            this.customAuthenticationProvider = customAuthenticationProvider;
        }

        

        public async Task<bool> Login(LoginModel loginModel)
        {
            var result = await client.PostAsJsonAsync("/api/Auth/login", loginModel);
            var content  = await result.Content.ReadFromJsonAsync<LoginResponse>();
            if (content.Result) 
            {
                Token = content.Token;
                await _localStorageService.SetItemAsync<string>("token", Token);
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            Token = null;
            await _localStorageService.RemoveItemAsync("token");
            //var state = await customAuthenticationProvider.GetAuthenticationStateAsync();
            _navigationManager.NavigateTo("/login");
        }

        public async Task<string> GetToken()
        {
            string token = null;
            try
            {
                token = await _localStorageService.GetItemAsync<string>("token");
            }
            catch (Exception) { }
            return token;
        }
    }
}
