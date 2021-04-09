using Data.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<SessionToken>> GetWithSessionTokensByIdAsync(int userId);
    }
}
