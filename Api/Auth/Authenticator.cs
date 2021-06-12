using System;
using System.Text;
using System.Threading.Tasks;
using SysMatur.Data.Objects;
using SysMatur.Data.Services;

namespace SysMatur.Api.Auth
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
                var newToken = GenToken();
                while (await _sessionTokenService.CheckExists(newToken)) newToken = GenToken();
                await _sessionTokenService.CreateSessionToken(new SessionToken
                    {EndOfValidity = DateTime.Today.AddDays(1), Owner = user, Token = newToken});
                return newToken;
            }

            return null;
        }

        public static string GenToken()
        {
            var rnd = new Random();
            var bytes = new byte[32];
            rnd.NextBytes(bytes);
            return Encoding.Default.GetString(bytes);
        }
    }
}