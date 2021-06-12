using System.Collections.Generic;
using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Services
{
    public interface ISessionTokenService
    {
        Task<SessionToken> CreateSessionToken(SessionToken newSessionToken);
        Task DeleteSessionToken(SessionToken sessionToken);
        Task Update(SessionToken sessionTokenToBeUpdated, SessionToken sessionToken);
        Task<IEnumerable<SessionToken>> GetSessionTokensByUser(User user);
        Task<User> GetUserBySessionToken(string sessionToken);
        Task<bool> CheckExists(string sessionToken);
    }
}