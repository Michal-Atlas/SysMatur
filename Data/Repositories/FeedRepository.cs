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
            return (await SysMaturDbContext.Users.Include(x => x.Feeds).FirstAsync(x => x.Username == username)).Feeds;
        }

        public async Task<Feed> CreateFeedAsync(Feed feed)
        {
            await SysMaturDbContext.Feeds.AddAsync(feed);
            await SysMaturDbContext.SaveChangesAsync();
            return feed;
        }

        public async Task DeleteFeedAsync(int feedId)
        {
            SysMaturDbContext.Feeds.Remove(await SysMaturDbContext.Feeds.FindAsync(feedId));
            // TODO: The Database should have a setting to handle this automatically find it an use it
            SysMaturDbContext.FeedRedditApis.RemoveRange(
                SysMaturDbContext.FeedRedditApis.Where(x => x.Base.Id == feedId));
            await SysMaturDbContext.SaveChangesAsync();
        }

        public async Task SetVisibility(int id, bool visibility)
        {
            (await SysMaturDbContext.Feeds.FindAsync(id)).Visible = visibility;
            await SysMaturDbContext.SaveChangesAsync();
        }

        public async Task ChangeUrl(int id, string url)
        {
            (await SysMaturDbContext.Feeds.FindAsync(id)).Url = url;
            await SysMaturDbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckOwnership(int userId, int feedId)
        {
            return (await SysMaturDbContext.Feeds.FindAsync(feedId)).Owner.Id == userId;
        }
    }
}