using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Repositories
{
    public class SessionTokenRepository : Repository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<SessionToken> ISessionTokenRepository.GetSessionTokenByIdAsync(int id)
        {
            return SysMaturDbContext.SessionTokens.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<User?> GetUserFromSessionToken(string sessionKey)
        {
            return (await SysMaturDbContext.SessionTokens.Include(x => x.Owner)
                    .FirstOrDefaultAsync(x => x.Token == sessionKey))
                ?.Owner;
        }

        public async Task<bool> CheckExists(string sessionToken)
        {
            return await SysMaturDbContext.SessionTokens.AnyAsync(x => x.Token == sessionToken);
        }
    }
}