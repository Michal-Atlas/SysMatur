using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    public interface IFeedService
    {
        Task<Feed> CreateFeed(Feed newFeed);
        Task DeleteFeed(Feed feed);
        Task Update(Feed feedToBeUpdated, Feed feed);
        Task<IEnumerable<Feed>> GetFeedsByUserId(int id);
    }
}