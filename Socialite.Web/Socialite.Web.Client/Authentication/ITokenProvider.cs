namespace Socialite.Web.Client.Authentication
{
    public interface ITokenProvider
    {
        public Task<string> GetToken();
    }
}
