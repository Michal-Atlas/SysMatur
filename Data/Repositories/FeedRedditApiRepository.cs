using System.Threading.Tasks;
using Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FeedRedditApiRepository : Repository<FeedRedditApi>, IFeedRedditApiRepository
    {
        public FeedRedditApiRepository(SysMaturDbContext context)
            : base(context)
        {
        }

        private SysMaturDbContext SysMaturDbContext => Context;

        Task<FeedRedditApi> IFeedRedditApiRepository.GetFeedRedditApiByIdAsync(int id)
        {
            return SysMaturDbContext.FeedRedditApis.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}