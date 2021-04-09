using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface ISessionTokenService
    {
        Task<SessionToken> CreateSessionToken(SessionToken newSessionToken);
        Task<SessionToken> DeleteSessionToken(SessionToken sessionToken);
        Task<SessionToken> Update(SessionToken sessionTokenToBeUpdated, SessionToken sessionToken);
        Task<IEnumerable<SessionToken>> GetSessionTokensByUser(int userId);
    }
}
