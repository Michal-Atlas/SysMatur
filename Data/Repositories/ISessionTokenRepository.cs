using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public interface ISessionTokenRepository : IRepository<SessionToken>
    {
        Task<SessionToken> GetSessionTokenByIdAsync(int id);
        Task<User?> GetUserFromSessionToken(string sessionKey);
    }
}