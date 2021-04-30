using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    public interface IFeedService
    {
        Task<Feed> CreateFeed(Feed newFeed);
        Task DeleteFeed(Feed feed);
        Task<IEnumerable<Feed>> GetFeedsByUserId(int id);
        Task<Feed> CreateAsync(Feed toFeed);
        Task<bool> CheckOwnership(int userId, int feedId);
        Task SetVisibility(int feedId, bool visibility);
        Task ChangeUrl(int feedId, string? url);
        Task DeleteAsync(int feedId);
        Task<IEnumerable<Feed>> GetByUsernameAsync(string userUsername);
    }
}