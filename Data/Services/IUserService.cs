using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task DeleteUser(User user);
        Task Update(User userToBeUpdated, User user);
        Task<User> GetUserByUsername(string userName);
        Task<User?> GetUserBySessionToken(string sessionKey);
    }
}