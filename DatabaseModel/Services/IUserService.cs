using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    interface IUserService
    {
        Task<User> CreateUser(User newUser);
        Task DeleteUser(User user);
        Task Update(User userToBeUpdated, User user);
    }
}
