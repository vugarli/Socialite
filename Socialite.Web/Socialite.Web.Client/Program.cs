using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Socialite.Web.Client.Authentication;
using Socialite.Web.Client.Services;
using Socialite.Web.Client.Services.Authentication;
using Socialite.Web.Client.Services.Post;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.Services.AddHttpClient("API", (sp, cl) =>
{
    cl.BaseAddress = new Uri("http://localhost:5115");
}).AddHttpMessageHandler<AuthMessageHandler>();

builder.Services.AddHttpClient("Auth", (sp, cl) =>
{
    cl.BaseAddress = new Uri("http://localhost:5115");
});



builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IAuthenticationServicee, AuthenticationService>();
builder.Services.AddScoped<AuthMessageHandler>();
//builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
