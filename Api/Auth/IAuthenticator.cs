using System.Threading.Tasks;
using Data.Objects;

namespace Api.Auth
{
    public interface IAuthenticator
    {
        Task<User?> VerifyClaim(string sessionKey);
        Task<string> CreateClaim(string userName, string passwordHash);
    }
}