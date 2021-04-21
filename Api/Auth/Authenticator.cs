using System;
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

        public async Task<string?> CreateClaim(string userName, string passwordHash)
        {
            var user = await _userService.GetUserByUsername(userName);
            if (user == null) return null;
            if (user.PasswordHash == passwordHash)
            {
                var rnd = new Random();
                var newToken = rnd.Next();
                while (!await _sessionTokenService.CheckExists(newToken.ToString("X"))) newToken = rnd.Next();
                _sessionTokenService.CreateSessionToken(new SessionToken
                    {EndOfValidity = DateTime.Today.AddDays(1), Owner = user, Token = newToken.ToString("X")});
                return newToken.ToString("X");
            }

            return null;
        }
    }
}