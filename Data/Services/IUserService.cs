using System.Threading.Tasks;
using Data.Objects;

namespace Data.Services
{
    internal interface IUserService
    {
        Task<User> CreateUser(User newUser);
        Task DeleteUser(User user);
        Task Update(User userToBeUpdated, User user);
    }
}