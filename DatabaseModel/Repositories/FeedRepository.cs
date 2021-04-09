using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public FeedRepository(SysMaturDbContext context)
            : base(context)
        { }

        Task<Feed> IFeedRepository.GetFeedByIdAsync(int id)
        {
            return SysMaturDbContext.Feeds.SingleOrDefaultAsync(a => a.Id == id);
        }
        private SysMaturDbContext SysMaturDbContext { get { return Context as SysMaturDbContext; } }
    }
}