using System.Collections.Generic;
using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Repositories
{
    public interface IFeedRepository : IRepository<Feed>
    {
        Task<IEnumerable<Feed>> GetByUserIdAsync(int id);
        Task<IEnumerable<Feed>> GetByUsernameAsync(string userUsername);
        Task<Feed> CreateAsync(Feed feed);
        Task DeleteAsync(int feedId);
        Task SetVisibility(int id, bool visibility);
        Task ChangeUrl(int id, string url);
        Task<bool> CheckOwnership(int userId, int feedId);
        Task<Feed> GetFeedByIdAsync(int id);
    }
}