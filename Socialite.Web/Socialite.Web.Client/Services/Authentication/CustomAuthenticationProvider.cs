﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace Socialite.Web.Client.Services.Authentication
{
    public class CustomAuthenticationProvider : AuthenticationStateProvider
    {
      
            private readonly ILocalStorageService _localStorage;
            private readonly HttpClient _http;

            public CustomAuthenticationProvider(ILocalStorageService localStorage, HttpClient http)
            {
                _localStorage = localStorage;
                _http = http;
            }

            public override async Task<AuthenticationState> GetAuthenticationStateAsync()
            {

            // throws exception with prerender enabled
            string token = await _localStorage.GetItemAsync<string>("token");
            
            if (string.IsNullOrEmpty(token)) return new AuthenticationState(null); ;

            var claims = ParseClaimsFromJwt(token);

            var expirationClaim = claims.FirstOrDefault(c=>c.Type == "exp");

            if (expirationClaim != null)
            {
                var expDate = DateTime.UnixEpoch.AddSeconds(Convert.ToInt64(expirationClaim.Value));

                if (DateTime.UtcNow > expDate)
                {
                    var authState = new AuthenticationState(new ClaimsPrincipal());
                    NotifyAuthenticationStateChanged(Task.FromResult(authState));
                    return authState;
                }
            }


            var identity = new ClaimsIdentity();
                _http.DefaultRequestHeaders.Authorization = null;

                if (!string.IsNullOrEmpty(token))
                {
                    identity = new ClaimsIdentity(claims, "jwt");
                    _http.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }

                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return state;
            }

            public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
            {
                var payload = jwt.Split('.')[1];
                var jsonBytes = ParseBase64WithoutPadding(payload);
                var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
                return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
            }

            private static byte[] ParseBase64WithoutPadding(string base64)
            {
                switch (base64.Length % 4)
                {
                    case 2: base64 += "=="; break;
                    case 3: base64 += "="; break;
                }
                return Convert.FromBase64String(base64);
            }
        }
}
