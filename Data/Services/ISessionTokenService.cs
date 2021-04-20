using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal interface ISessionTokenService
    {
        Task<SessionToken> CreateSessionToken(SessionToken newSessionToken);
        Task DeleteSessionToken(SessionToken sessionToken);
        Task Update(SessionToken sessionTokenToBeUpdated, SessionToken sessionToken);
        Task<IEnumerable<SessionToken>> GetSessionTokensByUser(int userId);
    }
}