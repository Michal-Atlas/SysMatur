using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public FeedRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<Feed> IFeedRepository.GetFeedByIdAsync(int id)
        {
            return SysMaturDbContext.Feeds.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Feed>> GetFeedsByUserIdAsync(int id)
        {
            return SysMaturDbContext.Users.Include(x => x.Feeds).FirstAsync(x => x.Id == id).Result.Feeds;
        }

        public async Task<IEnumerable<Feed>> GetFeedsByUsernameAsync(string username)
        {
            return SysMaturDbContext.Feeds.Where(x => x.Owner.Username == username);
        }
    }
}