using System.Threading.Tasks;
using Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FeedRssRepository : Repository<FeedRss>, IFeedRssRepository
    {
        public FeedRssRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<FeedRedditApi> IFeedRssRepository.GetFeedRedditApiByIdAsync(int id)
        {
            return SysMaturDbContext.FeedRedditApis.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}