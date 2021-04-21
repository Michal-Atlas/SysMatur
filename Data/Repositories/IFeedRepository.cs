using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public interface IFeedRepository : IRepository<Feed>
    {
        Task<Feed> GetFeedByIdAsync(int id);
        Task<IEnumerable<Feed>> GetFeedsByUserIdAsync(int id);
        Task<IEnumerable<Feed>> GetFeedsByUsernameAsync(string userUsername);
    }
}