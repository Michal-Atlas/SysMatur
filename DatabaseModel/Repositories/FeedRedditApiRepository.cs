using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public class FeedRedditApiRepository : Repository<FeedRedditApi>, IFeedRedditApiRepository
    {
        public FeedRedditApiRepository(SysMaturDbContext context)
            : base(context)
        { }

        Task<FeedRedditApi> IFeedRedditApiRepository.GetFeedRedditApiByIdAsync(int id)
        {
            return SysMaturDbContext.FeedRedditApis.SingleOrDefaultAsync(a => a.Id == id);
        }
        private SysMaturDbContext SysMaturDbContext { get { return Context as SysMaturDbContext; } }
    }
}
