using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal class SessionTokenService : ISessionTokenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SessionTokenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SessionToken>> GetSessionTokensByUser(int userId)
        {
            return await _unitOfWork.Users.GetWithSessionTokensByIdAsync(userId);
        }

        async Task<SessionToken> ISessionTokenService.CreateSessionToken(SessionToken newSessionToken)
        {
            await _unitOfWork.SessionTokens.AddAsync(newSessionToken);
            await _unitOfWork.CommitAsync();
            return newSessionToken;
        }

        async Task ISessionTokenService.DeleteSessionToken(SessionToken sessionToken)
        {
            _unitOfWork.SessionTokens.Remove(sessionToken);
            await _unitOfWork.CommitAsync();
        }

        async Task ISessionTokenService.Update(SessionToken sessionTokenToBeUpdated, SessionToken sessionToken)
        {
            sessionTokenToBeUpdated = sessionToken;
            await _unitOfWork.CommitAsync();
        }
    }
}