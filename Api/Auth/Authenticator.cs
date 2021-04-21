using System.Threading.Tasks;
using Data.Objects;
using Data.Services;

namespace Api.Auth
{
    public class Authenticator : IAuthenticator
    {
        private readonly ISessionTokenService _sessionTokenService;
        private readonly IUserService _userService;

        public Authenticator(ISessionTokenService sessionTokenService, IUserService userService)
        {
            _sessionTokenService = sessionTokenService;
            _userService = userService;
        }

        public async Task<User?> VerifyClaim(string sessionKey)
        {
            return await _sessionTokenService.GetUserBySessionToken(sessionKey);
        }
    }
}