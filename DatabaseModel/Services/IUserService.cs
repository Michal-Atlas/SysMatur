using DatabaseModel.Objects;
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
        Task<User> DeleteUser(User user);
        Task<User> Update(User userToBeUpdated, User user);
    }
}
