using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public class SessionTokenRepository : Repository<SessionToken>, ISessionTokenRepository
    {
        public SessionTokenRepository(SysMaturDbContext context)
            : base(context)
        { }

        Task<SessionToken> ISessionTokenRepository.GetSessionTokenByIdAsync(int id)
        {
            return SysMaturDbContext.SessionTokens.SingleOrDefaultAsync(a => a.Id == id);
        }
        private SysMaturDbContext SysMaturDbContext { get { return Context as SysMaturDbContext; } }
    }
}