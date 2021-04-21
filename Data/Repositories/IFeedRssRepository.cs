using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public interface IFeedRssRepository : IRepository<FeedRss>
    {
        Task<FeedRedditApi> GetFeedRedditApiByIdAsync(int id);
    }
}