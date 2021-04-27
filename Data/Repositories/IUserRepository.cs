using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Objects;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<SessionToken>> GetWithSessionTokensByIdAsync(int userId);
        Task<User> GetUserByUsernameAsync(string userName);
        Task<User> CreateUserAsync(User user);
        Task<bool> CheckExistsAsync(User userObj);
        Task ChangeUser(User oldUser, User newState);
    }
}