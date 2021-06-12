using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Api.Auth
{
    public interface IAuthenticator
    {
        Task<User?> VerifyClaim(string sessionKey);
        Task<string> CreateClaim(string userName, string passwordHash);
    }
}