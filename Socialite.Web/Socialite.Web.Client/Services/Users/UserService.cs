using Socialite.Common.Endpoints;
using Socialite.Web.Client.Models.Users;
using System.Net.Http.Json;

namespace Socialite.Web.Client.Services.Users
{
    public interface IUserService
    {
        public Task<UserInfoModel> GetCurrentUserInfo();
    }


    public class UserService : IUserService
    {
        private HttpClient _client { get; set; }
        public UserService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("API");
        }

        public async Task<UserInfoModel> GetCurrentUserInfo()
        {
            var result = await _client
                .GetFromJsonAsync<UserInfoModel>(UserEndpoints.CurrentUserInfoEndpoint);

            return result;
        }
    }
}
