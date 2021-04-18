using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public interface IFeedRedditApiRepository : IRepository<FeedRedditApi>
    {
        Task<FeedRedditApi> GetFeedRedditApiByIdAsync(int id);
    }
}