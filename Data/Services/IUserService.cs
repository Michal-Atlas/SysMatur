using System.Threading.Tasks;
using SysMatur.Data.Objects;

namespace SysMatur.Data.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User newUser);
        Task DeleteUser(User user);
        Task Update(User userToBeUpdated, User user);
        Task<User> GetUserByUsername(string userName);
        Task<User?> GetUserBySessionToken(string sessionKey);
        Task<User> GetUserFromSessionToken(string? requestCookie);
        Task<bool> CheckExistsAsync(User userObj);
        Task<User> CreateUserAsync(User userObj);
        Task<User> GetUserByUsernameAsync(string userName);
        Task ChangeUser(User? user, User userObj);
    }
}