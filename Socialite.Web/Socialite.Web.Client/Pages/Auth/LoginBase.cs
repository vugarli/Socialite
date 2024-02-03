using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Socialite.Web.Client.Models.Auth;
using Socialite.Web.Client.Services.Authentication;

namespace Socialite.Web.Client.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        public LoginModel LoginModel { get; set; } = new();
        public EditForm _editForm { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Inject]
        public AuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        IAuthenticationServicee AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var state = await AuthStateProvider.GetAuthenticationStateAsync();
            if((state?.User?.Identity?.IsAuthenticated ?? false) == true)
                _navigationManager.NavigateTo("/");
        }

        public async Task Login()
        {
            if (_editForm?.EditContext?.Validate() ?? false)
            {
                var result = await AuthenticationService.Login(LoginModel);
                if (result)
                { 
                    await AuthStateProvider.GetAuthenticationStateAsync();
                    _navigationManager.NavigateTo("/");
                }
                else
                    _snackbar.Add("Login failed",Severity.Error);
            }
        }

    }
}
