using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Repositories
{
    public interface ISessionTokenRepository : IRepository<SessionToken>
    {
        Task<SessionToken> GetSessionTokenByIdAsync(int id);
        Task<User?> GetUserFromSessionToken(string sessionKey);
        Task<bool> CheckExists(string sessionToken);
    }
}